using Application.AuthSettings;
using Application.Contracts.Identity;
using Application.Contracts.ILogging;
using Application.Exceptions;
using Application.Features.Commands.User.ClientUsers;
using Application.Features.Commands.User.LoginUsers;
using Application.IdentityModels;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Persistence.SeedConfig.UserRole;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository_Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IOptions<JwtSettings> _jwtSettings;
        private readonly IAppLogger<AuthService> _logger;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtSettings> jwtSettings, IAppLogger<AuthService> logger)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _jwtSettings = jwtSettings ?? throw new ArgumentNullException(nameof(jwtSettings));
            _logger = logger;
        }

        public async Task<RegistrationResponse> RegisterClientUserAsync(ClientUserCommand clientUser)
        {
            // Log the start of the registration process
            _logger.LogInformation("Starting user registration for email: {Email}", clientUser.Email);

            // Create a new application user
            var applicationUser = new ApplicationUser
            {
                FirstName = clientUser.FirstName,
                LastName = clientUser.LastName,
                Email = clientUser.Email,
                UserName = clientUser.Email,
                PhoneNumber = clientUser.PhoneNumber,
                Gender = clientUser.Gender,
                DateOfBirth = clientUser.DateOfBirth,
                Role = Roles.Client
            };

            // Attempt to create the user
            var result = await _userManager.CreateAsync(applicationUser, clientUser.Password);
            if (!result.Succeeded)
            {
                // Log the failure reason(s)
                _logger.LogWarning("User registration failed for email: {Email}. Errors: {Errors}", clientUser.Email, string.Join(", ", result.Errors.Select(e => e.Description)));
                throw new BadRequestException("User registration failed");
            }

            // Add the user to the specified role
            await _userManager.AddToRoleAsync(applicationUser, applicationUser.Role);

            // Log successful registration
            _logger.LogInformation("User registered successfully: {Email}", clientUser.Email);

            return new RegistrationResponse { UserId = applicationUser.Id };
        }

        public async Task<AuthResponse> LogInUserAsync(LoginUserCommand loginUser)
        {
            // Log the start of the method
            _logger.LogInformation("Attempting to log in user with email: {Email}", loginUser.Email);

            // Find the user by email
            var user = await _userManager.FindByEmailAsync(loginUser.Email);
            if (user == null)
            {
                // Log user not found
                _logger.LogWarning("User not found with email: {Email}", loginUser.Email);
                throw new NotFoundException("User not found", loginUser.Email);
            }

            // Check if the password is correct
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginUser.Password, false);
            if (result.Succeeded == false)
            {
                // Log invalid password attempt
                _logger.LogWarning("Invalid password attempt for user: {Email}", loginUser.Email);
                throw new UnauthorizedAccessException("Invalid credentials was entered for the user");
            }

            // Generate the JWT token
            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            // Log successful login
            _logger.LogInformation("User logged in successfully: {Email}", user.Email);

            // Create the response object
            var response = new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName
            };

            return response;
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

    }
}
