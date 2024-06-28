using Application.Exceptions;
using Application.Features.Commands.User.ClientUsers;
using Application.Features.Commands.User.LoginUsers;
using Application.Identity;
using Application.IdentityModels;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Persistence.SeedConfig;
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

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings;
        }

        public async Task<Unit> RegisterClientUserAsync(ClientUserCommand clientUser)
        {
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

            var result = await _userManager.CreateAsync(applicationUser, clientUser.Password);
            if (!result.Succeeded)
            {
                throw new Exception("Client user registration failed");
            }

            await _userManager.AddToRoleAsync(applicationUser, applicationUser.Role);
            return Unit.Value;
        }

        public async Task<Unit> LogInUserAsync(LoginUsersCommand loginUsers)
        {
            var user = await _userManager.FindByEmailAsync(loginUsers.Email);
            if (user == null)
            {
                throw new NotFoundException("User", loginUsers.Email);
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginUsers.Password, false);
            if (!result.Succeeded)
            {
                throw new NotFoundException("User", loginUsers.Email);
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            return Unit.Value;
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r.ToString()));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Value.Key));

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken
            (
               issuer: _jwtSettings.Value.Issuer,
               audience: _jwtSettings.Value.Audience,
               claims: claims,
               expires: DateTime.Now.AddMinutes(_jwtSettings.Value.DurationInMinutes),
               signingCredentials: signingCredentials
            );

            return jwtSecurityToken;
        }
    }
}
