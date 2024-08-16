using Application.AppURLSettings;
using Application.AuthSettings;
using Application.Contracts.Email;
using Application.Contracts.Identity;
using Application.Contracts.ILogging;
using Application.Exceptions;
using Application.Features.Commands.User.ClientUsers.Register;
using Application.Features.Commands.User.LoginUsers;
using Application.Features.Commands.User.UserPassword.ResetPassword.LoginUserPasswordReset;
using Application.Features.Commands.User.UserPassword.ResetPassword.NoneLoginUserPasswordReset;
using Application.IdentityModels;
using Domain;
using Domain.BaseResponse;
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
        private readonly string _clientAppUrl;

        public AuthService(UserManager<ApplicationUser> userManager,
                            SignInManager<ApplicationUser> signInManager,
                            IOptions<JwtSettings> jwtSettings,
                            IAppLogger<AuthService> appLogger,
                            IHttpContextAccessor httpContextAccessor,
                            IEmailSender emailSender,
                            IOptions<UrlSettings> appSettings)
        {
            _userManager = userManager /*?? throw new ArgumentNullException(nameof(userManager))*/;
            _signInManager = signInManager /*?? throw new ArgumentNullException(nameof(signInManager))*/;
            _jwtSettings = jwtSettings /*?? throw new ArgumentNullException(nameof(jwtSettings))*/;
            _appLogger = appLogger;
            _httpContextAccessor = httpContextAccessor;
            _emailSender = emailSender;
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
                Role = Roles.Client
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
                var roleResult = await _userManager.AddToRoleAsync(applicationUser, applicationUser.Role);

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

                // Create the response object
                var authResponse = new AuthResponse
                {
                    Id = user.Id,
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    Email = user.Email,
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
            // Retrieve claims associated with the user from the user manager
            var userClaims = await _userManager.GetClaimsAsync(user);

            // Retrieve roles associated with the user from the user manager
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
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Value.Key));

            // Define the signing credentials using the security key and HMAC-SHA256 algorithm
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512);

            // Create the JWT token with the specified issuer, audience, claims, expiration, and signing credentials
            var jwtSecurityToken = new JwtSecurityToken
            (
               issuer: _jwtSettings.Value.Issuer, // Token issuer
               audience: _jwtSettings.Value.Audience, // Token audience
               claims: claims, // Claims to include in the token
               expires: DateTime.Now.AddMinutes(_jwtSettings.Value.DurationInMinutes), // Token expiration time
               signingCredentials: signingCredentials // Signing credentials
            );

            // Return the generated JWT token
            return jwtSecurityToken;
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


        public async Task<AppResponse> ForgetPassword(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user != null)
                {
                    var confirmationToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                    confirmationToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(confirmationToken));
                    var callbackUrl = $"{_clientAppUrl}/reset-password?userId={user.Id}&code={confirmationToken}";

                    // Send email logic here
                    await _emailSender.ExternalPasswordResetEmailAsync(user.Email, callbackUrl);
                    //HtmlEncoder.Default.Encode(callbackUrl)
                    return new AppResponse
                    {
                        Exists = true,
                        Message = "A password reset link has been sent to your email."
                    };
                }
            }

            return new AppResponse
            {
                Exists = false,
                Message = "A password reset link has been sent to your email."
            };
        }

        public async Task<AppResponse> NoneLoginResetPassword(NoneLoginUserPasswordResetCommand resetPassword)
        {
            var user = await _userManager.FindByEmailAsync(resetPassword.Email);
            if (user == null)
            {
                return new AppResponse
                {
                    Exists = false,
                    Message = "User not valid"
                };
            }

            var token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(resetPassword.ResetToken));

            var resutlt = await _userManager.ResetPasswordAsync(user, token, resetPassword.Password);
            if (resutlt.Succeeded)
            {
                return new AppResponse
                {
                    Exists = true,
                    Message = "Your password has been reset"
                };
            }

            return new AppResponse
            {
                Exists = false,
                Message = "User not valid"
            };
        }

        public async Task<AppResponse> LoginUserPasswordReset(LoginUserPasswordResetCommand resetPassword)
        {
            var user = await _userManager.FindByIdAsync(resetPassword.Id);
            if (user == null)
            {
                return new AppResponse
                {
                    Exists = false,
                    Message = "User not valid"
                };
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, resetPassword.CurrentPassword, false);
            if (result.Succeeded)
            {
                var confirmationToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                confirmationToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(confirmationToken));

                var token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(confirmationToken));

                var resutlt = await _userManager.ResetPasswordAsync(user, token, resetPassword.NewPassword);
                if (resutlt.Succeeded)
                {
                    return new AppResponse
                    {
                        Exists = true,
                        Message = "Your password has been reset"
                    };
                }
            }
            else
            {
                return new AppResponse
                {
                    Exists = true,
                    Message = "Currnt password does not match"
                };
            }

            return new AppResponse
            {
                Exists = false,
                Message = "User not valid"
            };
        }
    }
}
