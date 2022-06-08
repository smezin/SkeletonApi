using SkeletonApi.Services.Interfaces;
using System.Threading.Tasks;
using SkeletonApi.Auth;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using SkeletonApi.Models.Entities;
using System.Linq;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using SkeletonApi.Models.AppRequests;
using Serilog;

namespace SkeletonApi.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;
        //private readonly ILogger _logger;
        public UserService(
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            IOptions<JWT> jwt
            //ILogger logger
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
            //_logger = logger;
        }
        public async Task<AuthenticationModel> GetTokenAsync(TokenRequestModel model)
        {
            var authenticationModel = new AuthenticationModel();
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null)
            {
                authenticationModel.IsAuthenticated = false;
                authenticationModel.Message = $"No Accounts Registered with {model.Email}.";
                //_logger.Information($"No Accounts Registered with {model.Email}.");
                return authenticationModel;
            }
            if (await _userManager.CheckPasswordAsync(user, model.Password))
            {
                //_logger.Information($"User with {model.Email} Authenticated");
                authenticationModel.IsAuthenticated = true;
                JwtSecurityToken jwtSecurityToken = await CreateJwtToken(user);
                authenticationModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                authenticationModel.Email = user.Email;
                authenticationModel.UserName = user.UserName;
                var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
                authenticationModel.Roles = rolesList.ToList();
                return authenticationModel;
            }
            authenticationModel.IsAuthenticated = false;
            //_logger.Information($"User with {model.Email} Unauthorized");
            authenticationModel.Message = $"Incorrect Credentials for user {user.Email}.";
            return authenticationModel;
        }
        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim("roles", role));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
        public async Task<string> RegisterAsync(RegisterModel model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            var userWithSameEmail = await _userManager.FindByEmailAsync(model.Email);
            if (userWithSameEmail is null)
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Authorization.default_role.ToString());
                    //_logger.Information($"User Registered with username {user.UserName}");
                    return $"User Registered with username {user.UserName} and rmail {user.Email}.";
                }
                else
                {
                    //_logger.Warning($"Failed creating user with username {user.UserName}");
                    return $"Unexpected error Registering username {user.UserName}";
                }
            }
            else
            {
                //_logger.Warning($"Email {user.Email } is already registered.");
                return $"Email {user.Email } is already registered.";
            }
        }
    }
}
