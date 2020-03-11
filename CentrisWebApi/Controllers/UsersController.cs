using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CentrisWebApi.Data.IRepositories;
using CentrisWebApi.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CentrisWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController: ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        public UsersController(IConfiguration config, IUserRepository repo, IMapper mapper)
        {
            _config = config;
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _repo.GetAll();
            var usersToReturn = _mapper.Map<IEnumerable<UsersForListDTO>>(result);
            return Ok(usersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _repo.GetUserById(id);
            var userToReturn = _mapper.Map<UserForDetailedDTO>(result);
            return Ok(userToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserForUpdateDTO dto)
        {
           
            if(id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            return Unauthorized();
            var userFromRepo = await _repo.GetUserById(id);
            _mapper.Map(dto,userFromRepo);
            if(await _repo.SaveAll())
            return NoContent();
            throw new System.Exception($"Updating data {id} failed.");
        }
    }
}