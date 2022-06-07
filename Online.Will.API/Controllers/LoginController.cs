using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Online.Will.API.Data;
using Online.Will.API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Online.Will.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;
        public LoginController(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            var user = _dataContext.PersonalDetails.Where(u => u.Email == login.Email && u.Password == login.Password).FirstOrDefault();

            if (user == null)
                return BadRequest("User does not exist!");

            var token = GenerateToken(user);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }
        private JwtSecurityToken GenerateToken(PersonalDetails personal)
        {

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, personal.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(+3), //Expires 2 hours after 11:00
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}