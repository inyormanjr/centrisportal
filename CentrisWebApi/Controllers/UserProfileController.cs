using System.Threading.Tasks;
using CentrisWebApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CentrisWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController:ControllerBase
    {
        private readonly CentrisDataContext _context;
        private ILogger<UserProfileController> _logger;
        public UserProfileController(CentrisDataContext context, ILogger<UserProfileController> logger){
            _context  = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserProfile()
        {
            
            var result = await _context.UserProfiles.ToListAsync();
            if(result.Count == 0)
            {
                return NotFound("No data found");
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserProfile(int id)
        {
            var result = await _context.UserProfiles.FirstOrDefaultAsync(x=> x.Id == id);
            if(result == null)
            {
                return NotFound("No data found");
            }
            return Ok(result);
        }
    }
}