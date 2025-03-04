using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace RealEstate_Dapper_Api.Tools;

public class JwtTokenGenerator {
    public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel user) {
        var claims = new List<Claim>();
        if (!string.IsNullOrWhiteSpace(user.Role))
            claims.Add(new Claim(ClaimTypes.Role, user.Role));

        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        if (!string.IsNullOrWhiteSpace(user.Username))
            claims.Add(new Claim("Username", user.Username));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefault.Key));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefault.Expire);
        JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefault.ValidIssuer,
            audience: JwtTokenDefault.ValidAudience, claims: claims, expires: expireDate,
            signingCredentials: signingCredentials, notBefore: DateTime.UtcNow);
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        return new TokenResponseViewModel(tokenHandler.WriteToken(token), expireDate);
    }
}
