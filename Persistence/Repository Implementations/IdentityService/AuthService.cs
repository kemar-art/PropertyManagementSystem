using Application.AppURLSettings;
using Application.AuthSettings;
using Application.Contracts.Email;
using Application.Contracts.Identity;
using Application.Contracts.ILogging;
using Application.Exceptions;
using Application.Features.Commands.User.ClientUsers.Register;
using Application.Features.Commands.User.LoginUsers;
using Application.Features.Commands.User.UserPassword.ForgetPassword.Admins;
using Application.Features.Commands.User.UserPassword.ResetPassword.LoginUserPasswordReset;
using Application.Features.Commands.User.UserPassword.ResetPassword.NoneLoginUserPasswordReset;
using Application.IdentityModels;
using Domain;
using Domain.Common;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Persistence.SeedConfig.UserRole;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Persistence.Repository_Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IOptions<JwtSettings> _jwtSettings;
        private readonly IAppLogger<AuthService> _appLogger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly string _clientAppUrl;

        public AuthService(UserManager<ApplicationUser> userManager,
                            SignInManager<ApplicationUser> signInManager,
                            IOptions<JwtSettings> jwtSettings,
                            IAppLogger<AuthService> appLogger,
                            IHttpContextAccessor httpContextAccessor,
                            IEmailSender emailSender,
                            RoleManager<IdentityRole> roleManager,
                            IOptions<UrlSettings> appSettings)
        {
            _userManager = userManager /*?? throw new ArgumentNullException(nameof(userManager))*/;
            _signInManager = signInManager /*?? throw new ArgumentNullException(nameof(signInManager))*/;
            _jwtSettings = jwtSettings /*?? throw new ArgumentNullException(nameof(jwtSettings))*/;
            _appLogger = appLogger;
            _httpContextAccessor = httpContextAccessor;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _clientAppUrl = appSettings.Value.ClientAppUrl;
        }

        public async Task<BaseResult<RegistrationResponse>> RegisterClientUserAsync(ClientRegistrationCommand clientUser)
        {
            _appLogger.LogInformation("Starting user registration for email: {Email}", clientUser.Email);

            // Create a new application user
            var applicationUser = new ApplicationUser
            {
                FirstName = clientUser.FirstName,
                LastName = clientUser.LastName,
                Email = clientUser.Email,
                UserName = clientUser.Email,
                Address = clientUser.Address,
                NormalizedEmail = clientUser.Email.ToUpper(),
                NormalizedUserName = clientUser.Email.ToUpper(),
                PhoneNumber = clientUser.PhoneNumber,
                Gender = clientUser.Gender,
                DateOfBirth = clientUser.DateOfBirth,
                DateRegistered = DateTime.Now,
                ClientRegionId = clientUser.ClientRegionId,
            };

            try
            {
                // Attempt to create the user
                var result = await _userManager.CreateAsync(applicationUser, clientUser.Password);

                if (!result.Succeeded)
                {
                    // Log the failure reason(s)
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    _appLogger.LogWarning("User registration failed for email: {Email}. Errors: {Errors}", clientUser.Email, errors);
                    return BaseResult<RegistrationResponse>.Failure($"User registration failed: {errors}");
                }

                // Add the user to the specified role
                var roleResult = await _userManager.AddToRoleAsync(applicationUser, Roles.Client);

                if (!roleResult.Succeeded)
                {
                    var roleErrors = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                    _appLogger.LogWarning("Adding user to role failed for email: {Email}. Errors: {Errors}", clientUser.Email, roleErrors);
                    return BaseResult<RegistrationResponse>.Failure($"Failed to assign role: {roleErrors}");
                }

                // Log successful registration
                _appLogger.LogInformation("User registered successfully: {Email}", clientUser.Email);

                return BaseResult<RegistrationResponse>.Success(new RegistrationResponse { UserId = applicationUser.Id });
            }
            catch (Exception ex)
            {
                _appLogger.LogError("An unexpected error occurred during user registration for email: {Email}", clientUser.Email, ex);
                return BaseResult<RegistrationResponse>.Failure("An unexpected error occurred. Please try again later.");
            }
        }

        public async Task<BaseResult<AuthResponse>> LogInUserAsync(LoginUserCommand loginUser)
        {
            // Log the start of the method
            _appLogger.LogInformation("Attempting to log in user with email: {Email}", loginUser.Email);

            try
            {
                // Find the user by email
                var user = await _userManager.FindByEmailAsync(loginUser.Email);
                if (user == null)
                {
                    // Log user not found and return failure
                    _appLogger.LogWarning("User not found with email: {Email}", loginUser.Email);
                    return BaseResult<AuthResponse>.Failure($"User not found with email: {loginUser.Email}");
                }

                // Check if the password is correct
                var passwordCheckResult = await _signInManager.CheckPasswordSignInAsync(user, loginUser.Password, false);
                if (!passwordCheckResult.Succeeded)
                {
                    // Log invalid password attempt and return failure
                    _appLogger.LogWarning("Invalid password attempt for user: {Email}", loginUser.Email);
                    return BaseResult<AuthResponse>.Failure("Invalid credentials provided.");
                }

                // Generate the JWT token
                JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

                // Log successful login
                _appLogger.LogInformation("User logged in successfully: {Email}", user.Email);


                var userRoles = await _userManager.GetRolesAsync(user);
                var role = userRoles.FirstOrDefault();

                // Create the response object
                var authResponse = new AuthResponse
                {
                    Id = user.Id,
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    Email = user.Email,
                    Role = role,
                    UserName = user.UserName
                };

                // Return success result
                return BaseResult<AuthResponse>.Success(authResponse);
            }
            catch (Exception ex)
            {
                // Log unexpected exception and return failure
                _appLogger.LogError("An unexpected error occurred during login: {Exception}", ex);
                return BaseResult<AuthResponse>.Failure("An unexpected error occurred. Please try again later.");
            }
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            // Retrieve user claims and roles from the user manager
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            // Convert roles into claims
            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r.ToString()));

            // Define a base set of claims for the token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName), // Subject (user identifier)
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // JWT ID (unique token identifier)
                new Claim(JwtRegisteredClaimNames.Email, user.Email), // User email
                new Claim("uid", user.Id) // Custom claim for user ID
            }
            .Union(userClaims) // Add user claims
            .Union(roleClaims); // Add role claims

            // Create a symmetric security key from the JWT settings
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Value.Key));

            // Define the signing credentials using the security key and HMAC-SHA256 algorithm
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            // Create the JWT token with the specified issuer, audience, claims, expiration, and signing credentials
            var jwtToken = new JwtSecurityToken
            (
               issuer: _jwtSettings.Value.Issuer,
               audience: _jwtSettings.Value.Audience,
               claims: claims, // Claims to include in the token
               expires: DateTime.Now.AddMinutes(_jwtSettings.Value.DurationInMinutes),
               signingCredentials: signingCredentials
            );

            // Return the generated JWT token
            return jwtToken;
        }

        public async Task<BaseResult<bool>> IsEmailRegisteredExist(string email)
        {
            try
            {
                // Log the start of the email existence check
                _appLogger.LogInformation("Checking if email is registered: {Email}", email);

                var user = await _userManager.FindByEmailAsync(email);
                var isRegistered = user != null;

                // Log the result of the email check
                _appLogger.LogInformation("Email {Email} registered: {IsRegistered}", email, isRegistered);

                return BaseResult<bool>.Success(isRegistered);
            }
            catch (Exception ex)
            {
                // Log any unexpected errors
                _appLogger.LogError("An error occurred while checking if email is registered: {Email}", email, ex);

                // Return a failure result with the error message
                return BaseResult<bool>.Failure("An error occurred while checking the email.");
            }
        }

        public async Task<CustomResponse> ForgetPassword(string email)
        {
            // Find the user by their email
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                // Log that no user was found with the provided email
                _appLogger.LogWarning("ForgetPassword request for non-existing email: {Email}", email);

                return new CustomResponse
                {
                    IsSuccess = false,
                    Message = "A password reset link was sent to your email."
                };
            }

            // Generate a password reset token
            var confirmationToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(confirmationToken));

            // Construct the callback URL for resetting the password
            var callbackUrl = $"{_clientAppUrl}/reset-password?userId={user.Id}&code={encodedToken}";

            // Send the password reset email
            await _emailSender.ExternalPasswordResetEmailAsync(user.Email, callbackUrl);

            // Log the successful sending of the reset email
            _appLogger.LogInformation("Password reset email sent to: {Email}", email);

            return new CustomResponse
            {
                IsSuccess = true,
                Message = "A password reset link was sent to your email."
            };
        }

        public async Task<CustomResponse> AdminForgetPassword(string email)
        {
            // Log the start of the password reset request
            _appLogger.LogInformation("Received a request to reset password for email: {Email}", email);

            // Attempt to find the user by email
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                // Log that no user was found with the provided email
                _appLogger.LogWarning("ForgetPassword email request for non-existing email: {Email}", email);

                // Throw a 404 Not Found exception
                throw new NotFoundException(nameof(AdminForgetPasswordRestCommand), email);
            }

            // Check if the user is in the Client role
            var role = await _userManager.IsInRoleAsync(user, Roles.Client);
            if (role)
            {
                // Log an unauthorized access attempt
                _appLogger.LogWarning("Unauthorized password reset attempt for user: {Email}", email);

                // Throw a 400 Bad Request exception
                throw new BadRequestException("The user is not authorized to use the admin portal");
            }

            // Log the generation of the password reset token
            _appLogger.LogInformation("Generating password reset token for user: {Email}", email);

            // Generate a password reset token
            var confirmationToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(confirmationToken));

            // Construct the callback URL for resetting the password
            var callbackUrl = $"{_clientAppUrl}/reset-password?userId={user.Id}&code={encodedToken}";

            // Send the password reset email
            await _emailSender.ExternalPasswordResetEmailAsync(user.Email, callbackUrl);

            // Log the successful sending of the password reset email
            _appLogger.LogInformation("Password reset email successfully sent to: {Email}", email);

            // Return a successful response
            return new CustomResponse
            {
                IsSuccess = true,
                Message = "A password reset link was sent to your email."
            };
        }


        public async Task<CustomResponse> NoneLoginResetPassword(NoneLoginUserPasswordResetCommand resetPassword)
        {
            // Log the start of the password reset process
            _appLogger.LogInformation("Attempting to reset password for user ID: {UserId}", resetPassword.Id);

            // Find the user by their ID
            var user = await _userManager.FindByIdAsync(resetPassword.Id);
            if (user == null)
            {
                // Log that the user was not found
                _appLogger.LogWarning("User not found with ID: {UserId}", resetPassword.Id);

                return new CustomResponse
                {
                    IsSuccess = false,
                    Message = "User not valid"
                };
            }

            // Verify the email
            if (!string.Equals(user.Email, resetPassword.Email, StringComparison.OrdinalIgnoreCase))
            {
                // Log that the email verification failed
                _appLogger.LogWarning("Email verification failed for user ID: {UserId}, provided email: {Email}", resetPassword.Id, resetPassword.Email);

                return new CustomResponse
                {
                    IsSuccess = false,
                    Message = "User not valid"
                };
            }

            // Decode reset token
            var decodedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(resetPassword.ResetToken));

            // Attempt to reset the password
            var result = await _userManager.ResetPasswordAsync(user, decodedToken, resetPassword.Password);
            if (result.Succeeded)
            {
                // Log the successful password reset
                _appLogger.LogInformation("Password reset successful for user ID: {UserId}", resetPassword.Id);

                return new CustomResponse
                {
                    IsSuccess = true,
                    Message = "Your password has been reset"
                };
            }

            // Log that the password reset failed
            _appLogger.LogError("Password reset failed for user ID: {UserId}", resetPassword.Id);

            // Handle failure
            return new CustomResponse
            {
                IsSuccess = false,
                Message = "Password reset failed"
            };
        }

        public async Task<CustomResponse> LoginUserPasswordReset(LoginUserPasswordResetCommand resetPassword)
        {
            // Log the start of the password reset process
            _appLogger.LogInformation("Attempting to reset password for user ID: {UserId}", resetPassword.Id);

            // Find the user by their ID
            var user = await _userManager.FindByIdAsync(resetPassword.Id);
            if (user == null)
            {
                // Log that the user was not found
                _appLogger.LogWarning("User not found with ID: {UserId}", resetPassword.Id);

                return new CustomResponse
                {
                    IsSuccess = false,
                    Message = "User not valid"
                };
            }

            // Check if the current password is correct
            var passwordCheckResult = await _signInManager.CheckPasswordSignInAsync(user, resetPassword.CurrentPassword, false);
            if (!passwordCheckResult.Succeeded)
            {
                // Log that the current password does not match
                _appLogger.LogWarning("Current password does not match for user ID: {UserId}", resetPassword.Id);

                return new CustomResponse
                {
                    IsSuccess = true,
                    Message = "Current password does not match"
                };
            }

            // Generate a password reset token
            var confirmationToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            confirmationToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(confirmationToken));

            // Decode the token (This step might not be necessary if the token is directly usable)
            var decodedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(confirmationToken));

            // Attempt to reset the password
            var resetResult = await _userManager.ResetPasswordAsync(user, decodedToken, resetPassword.NewPassword);
            if (resetResult.Succeeded)
            {
                // Log the successful password reset
                _appLogger.LogInformation("Password reset successful for user ID: {UserId}", resetPassword.Id);

                return new CustomResponse
                {
                    IsSuccess = true,
                    Message = "Your password has been reset"
                };
            }

            // Log the failure to reset the password
            _appLogger.LogError("Password reset failed for user ID: {UserId}", resetPassword.Id);

            // Return a failure response
            return new CustomResponse
            {
                IsSuccess = false,
                Message = "Password reset failed"
            };
        }

    }
}
