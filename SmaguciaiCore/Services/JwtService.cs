using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Academy.Core.ApiSettings;
using Microsoft.IdentityModel.Tokens;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Responses.User;

namespace SmaguciaiCore.Services;

public class JwtService : IJwtService
{
    private readonly JwtSettings _jwtSettings;
    
    private const string HashAlgorithm = SecurityAlgorithms.HmacSha256Signature;
    private readonly JwtSecurityTokenHandler _tokenHandler;
    private readonly SymmetricSecurityKey _securityKey;
    
    public JwtService(JwtSettings jwtSettings)
    {
        _jwtSettings = jwtSettings;
        _tokenHandler = new JwtSecurityTokenHandler();
        _securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret));
    }
    
    public JwtResponse BuildJwt(UserResponse user)
    {
        var tokenDescriptor = CreateAccessTokenDescriptor(user);
        var securityToken = _tokenHandler.CreateToken(tokenDescriptor);

        return new JwtResponse()
        {
            AccessToken = _tokenHandler.WriteToken(securityToken),
        };
    }
    
    private SecurityTokenDescriptor CreateAccessTokenDescriptor(UserResponse user)
    {
        var claims = new List<Claim>
        {			
            new(ClaimTypes.Sid, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.Add(_jwtSettings.TokenLifetime),
            SigningCredentials = new SigningCredentials(_securityKey, HashAlgorithm),
        };

        return tokenDescriptor;
    }
}