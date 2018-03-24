using DotNetCorePayroll.Data.ViewModels;
using DotNetCorePayroll.ServiceBusinessRules.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DotNetCorePayroll.Api.Providers
{
    public class LoginProvider
    {
        private IConfiguration configuration;
        private IAccountService accountService;

        public LoginProvider(IConfiguration configuration, IAccountService accountService)
        {
            this.configuration = configuration;
            this.accountService = accountService;
        }

        public UserModel Login(LoginModel loginmodel)
        {
            UserModel user = accountService.Login(loginmodel);

            user.Token = new JwtSecurityTokenHandler().WriteToken(CreateToken(user));

            return user;
        }

        private JwtSecurityToken CreateToken(UserModel userModel)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["token:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = GetClaims(userModel);

            var token = new JwtSecurityToken(
                 issuer: configuration["token:issuer"],
                 audience: configuration["token:audience"],
                 claims: claims,
                 expires: DateTime.Now.AddMinutes(30),
                 signingCredentials: creds);

            return token;
        }

        private List<Claim> GetClaims(UserModel userModel)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userModel.Id.ToString()),
                new Claim("Username", userModel.Id.ToString()),
                new Claim("OrganisationId", userModel.OrganisationId.ToString())
            };

            if (userModel.CompanyId != null)
            {
                claims.Add(new Claim("CompanyId", userModel.CompanyId.Value.ToString()));
            }

            claims.Add(new Claim("RoleId", userModel.RoleId.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, userModel.RoleName));

            return claims;
        }
    }
}
