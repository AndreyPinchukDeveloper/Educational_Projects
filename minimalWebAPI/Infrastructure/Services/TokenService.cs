public class TokenService : ITokenService
{
    private TimeSpan ExpiryDuration = new TimeSpan(0,30,0);//available 30 minutes
    public string BuildToken(string key, string issuer, UserDto user)
    {
        var claims = new []
        {
            new Claim(ClaimTypes.Name, user.userName),
            new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
            expires: DateTime.Now.Add(ExpiryDuration), signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}