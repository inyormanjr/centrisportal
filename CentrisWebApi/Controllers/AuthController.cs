using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
    public class AuthController : ControllerBase
    {

        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper mapper;
        public AuthController(IAuthRepository repo, IConfiguration config, IMapper _mapper)
        {
            _repo = repo;
            _config = config;
            mapper = _mapper;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserForRegistrationDTO userForRegistrationDTO)
        {

            userForRegistrationDTO.Username = userForRegistrationDTO.Username.ToLower();

            if (await _repo.UserExists(userForRegistrationDTO.Username))
                return BadRequest("Username already exist.");

            var userToCreate = mapper.Map<User>(userForRegistrationDTO);
            var createdUser = await _repo.Register(userToCreate, userForRegistrationDTO.Password);
            var userToReturn = mapper.Map<UserForDetailedDTO>(createdUser);
            return CreatedAtRoute("GetUser", new {controoler = "Users", id = createdUser.Id}, userToReturn);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDTO userForLoginDTO)
        {
            var userFromRepo = await _repo.Login(userForLoginDTO.Username.ToLower(), userForLoginDTO.Password);

            if (userFromRepo == null)

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
            token = tokenHandler.CreateToken(tokenDescriptor);

            var user = mapper.Map<UserForDetailedDTO>(userFromRepo);
            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                user
            });
        }
    }
}