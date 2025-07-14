using CQRSAndMediatRDemo.Data;
using CQRSAndMediatRDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAndMediatRDemo.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthonticationController : ControllerBase
    {
        private readonly DbContextClass _dbContext;

        public AuthonticationController(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LogIn model , [FromServices] JwtTokenService jwttokenservice)
        {
            if (model == null || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest("Invalid login request");
            }
            else
            {
                // validate user credentials
                var user = _dbContext.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                if (user == null)
                {
                    return Unauthorized("Invalid credentials");
                }
                else
                {
                    var token = jwttokenservice.GenerateToken(model.Email);
                    return Ok(new { Token = token, Message = "Login successful" });
                    
                }
                // This is a placeholder for the login logic.
                // In a real application, you would validate the user's credentials and return a token or user information.
            } //return Ok(new { Message = "Login successful" });
        }
    }
}
