using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CentrisWebApi.Data;
using CentrisWebApi.DTO;
using CentrisWebApi.models.UserAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CentrisWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController:ControllerBase
    {

        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserForRegistrationDTO userForRegistrationDTO)
        {
           
            userForRegistrationDTO.Username = userForRegistrationDTO.Username.ToLower();
            
            if(await _repo.UserExists(userForRegistrationDTO.Username))
                return BadRequest("Username already exist.");

                var userToCreate = new User{
                    username = userForRegistrationDTO.Username
                };

                var createdUser = await _repo.Register(userToCreate, userForRegistrationDTO.Password);
                return StatusCode(201);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserForLoginDTO userForLoginDTO)
        {
            var userFromRepo = await _repo.Login(userForLoginDTO.Username.ToLower(), userForLoginDTO.Password);

            if(userFromRepo == null)
                return Unauthorized();

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                    new Claim(ClaimTypes.Name, userFromRepo.username)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes(_config.GetSection("AppSettings:Token").Value));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = creds,
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                    SecurityToken token;
                try
                {
                 token = tokenHandler.CreateToken(tokenDescriptor);
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                return Ok(new {
                    token = tokenHandler.WriteToken(token)
                });
        }
    }
}