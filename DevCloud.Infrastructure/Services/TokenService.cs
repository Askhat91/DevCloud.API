using DevCloud.Core.DTOs;
using DevCloud.Core.Entities;
using DevCloud.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DevCloud.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly DevCloudContext _db;
        private readonly IConfiguration _conf;

        public TokenService(DevCloudContext db, IConfiguration conf)
        {
            _db = db;
            _conf = conf;
        }

        public Token Create(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Login)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_conf["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.Add(TimeSpan.Parse(_conf["JwtAccessLifeTime"]));

            var token = new JwtSecurityToken(
                _conf["JwtIssuer"],
                _conf["JwtAudience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            string accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            Token newToken = new Token()
            {
                AccessToken = accessToken,
                UserLogin = user.Login,
                UserName = user.FirstName + " " + user.LastName
            };

            return newToken;
        }
    }
}
