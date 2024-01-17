using HotelReservationSystemData.ModelsFor;
using HotelReservationSystemData.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAdminRepository repository;
        private readonly IConfiguration configuration;

        public AuthenticationController(IAdminRepository repository , IConfiguration configuration)
        {
            this.repository = repository;
            this.configuration = configuration;
        }
        [HttpPost]
        public async Task<ActionResult<string>> Authenticat(AuthRequest authRequest)
        {
            var user = await repository.ValidateUserCredentials(authRequest.UserName, authRequest.Password);
            if(user == null) 
                return Unauthorized();
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("sup", user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, "Administartor"));
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Authentication:SecretKey"]));

            var signingCred = new SigningCredentials(securityKey , SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
               configuration["Authentication:Issuer"],
               configuration["Authentication:Audience"],
               claims,
               DateTime.UtcNow,
               DateTime.UtcNow.AddHours(10),
               signingCred
                );
            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return Ok(token);
        }
    }
}
