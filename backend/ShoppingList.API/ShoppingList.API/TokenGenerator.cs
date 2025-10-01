using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace ShoppingList.API;

public class TokenGenerator
{
    public string GenerateToken(string email)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        
        // TODO: Replace this and store it in a secure location
        var key = "*^MKF1UHhd9wII@iGI*QE%&2BegrtYPr"u8.ToArray();

        var claims = new Claim[]
        {
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new (JwtRegisteredClaimNames.Sub, email),
            new (JwtRegisteredClaimNames.Email, email)
        };
        
        var tokenDescriptors = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(1),
            Issuer = "ShoppingListAPI",
            Audience = "ShoppingListAPIClient",
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        
        var token = tokenHandler.CreateToken(tokenDescriptors);

        return tokenHandler.WriteToken(token);
    }
}