using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CentrisWebApi.Data.IRepositories;
using CentrisWebApi.DTO;
using CentrisWebApi.helpers;
using CentrisWebApi.models.Testimonials;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CentrisWebApi.Controllers
{
    [ServiceFilter(typeof(LogUserActivityFilter))]
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
        public async Task<IActionResult> GetUsers([FromQuery]UserParams userParams)
        {
            var result = await _repo.GetAll(userParams);
            var usersToReturn = _mapper.Map<IEnumerable<UsersForListDTO>>(result);

            Response.AddPagination(result.CurrentPage, result.PageSize, 
            result.TotalCount, result.TotalPage);

            return Ok(usersToReturn);
        }

        [HttpGet("{id}", Name = "GetUser")]
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

        [HttpPost("testimonials/{id}")]
        public async Task<IActionResult> AddTestimonials(int id, TestimonialForAddDTO dto)
        {
              if(id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
                var userFromRepo = await _repo.GetUserById(dto.UserId);
                var mapped_ = _mapper.Map<Testimonial>(dto);
                userFromRepo.Testimonials.Add(mapped_);
                if(await _repo.SaveAll())
                {
                    var result = _mapper.Map<TestimonialForUpdateDTO>(mapped_);
                    return Ok(result);
                }

                throw new System.Exception("Testimonial adding failed.");
        }

        [HttpGet("{userId}/testimonials/{id}")]
        public async Task<IActionResult> GetTestimonials(int userId,int id)
        {
            if(userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            return Unauthorized();

            var result =  await _repo.GetUserById(id);
            var mapped_ = _mapper.Map<TestimonialForUpdateDTO[]>(result.Testimonials);
            return Ok(mapped_);
        }
    }
}