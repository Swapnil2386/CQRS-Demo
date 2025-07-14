using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using CQRSAndMediatRDemo.Data;
using CQRSAndMediatRDemo.Models;

public class JwtTokenService
{
    private readonly IConfiguration _configuration;
    private readonly DbContextClass _dbContext;

    public JwtTokenService(IConfiguration configuration, DbContextClass dbContext)
    {
        _configuration = configuration;
        _dbContext = dbContext;
    }

    public string GenerateToken(string userEmail)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Email, userEmail)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expiry = DateTime.UtcNow.AddHours(1);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: expiry,
            signingCredentials: creds);

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        // Save token in DB
        _dbContext.JwtTokens.Add(new JwtToken
        {
            Token = tokenString,
            ExpiryDate = expiry,
            UserEmail = userEmail
        });
        _dbContext.SaveChanges();

        return tokenString;
    }
}