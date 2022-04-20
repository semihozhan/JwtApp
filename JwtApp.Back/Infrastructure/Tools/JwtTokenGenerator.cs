using JwtApp.Back.Core.Application.Dto;
using JwtApp.Back.Core.Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtApp.Back.Infrastructure.Tools
{
    public class JwtTokenGenerator
    {
        public static JwtTokenResponse GenerateToken(CheckUserResponseDto checkUserResponseDto)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenSettings.Key));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, checkUserResponseDto.Role));
            claims.Add(new Claim(ClaimTypes.Name, checkUserResponseDto.Username));
            claims.Add(new Claim(ClaimTypes.NameIdentifier,checkUserResponseDto.Id.ToString()));

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: JwtTokenSettings.Issuer,
                audience: JwtTokenSettings.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(JwtTokenSettings.Expire),
                signingCredentials: signingCredentials
                ); 
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
           
            return new JwtTokenResponse(handler.WriteToken(jwtSecurityToken));
        }
    }
}
