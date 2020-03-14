using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CentrisWebApi.Data.IRepositories;
using CentrisWebApi.DTO;
using CentrisWebApi.helpers;
using CentrisWebApi.models.UserAgg;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CentrisWebApi.Controllers
{
    [Authorize]
    [Route("api/users/{userId}/photos")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IOptions<CloudinarySettings> cloudinaryConfig;
        private Cloudinary _cloudinary;
        private readonly IUserRepository repo;
        public PhotosController(IUserRepository repo, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            this.repo = repo;
            this.cloudinaryConfig = cloudinaryConfig;
            this.mapper = mapper;

            Account acc = new Account(
                cloudinaryConfig.Value.CloudName,
                cloudinaryConfig.Value.ApiKey,
                cloudinaryConfig.Value.ApiSecret
            );
            _cloudinary = new Cloudinary(acc);
        }

        [HttpGet("{id}", Name = "GetPhoto")]
        public async Task<IActionResult> GetPohoto(int id)
        {
            var photoFromRepo = await repo.GetPhotoById(id);

            var photo = mapper.Map<PhotoForReturnDTO>(photoFromRepo);
            return Ok(photo);
        }


        [HttpPost]
        public async Task<IActionResult> AddPhotoForUser(int userId, [FromForm]PhotoForCreationDTO photoForCreationDTO)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var userFromRepo = await repo.GetUserById(userId);

            var file = photoForCreationDTO.File;
            var uploadResult = new ImageUploadResult();
            if (file.Length < 1)
                return BadRequest("No Image found");

            using (var stream = file.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.Name, stream),
                    Transformation = new Transformation()
                    .Width(500).Height(500).Crop("fill").Gravity("face")
                };
                uploadResult = _cloudinary.Upload(uploadParams);
            }


            photoForCreationDTO.Url = uploadResult.Uri.ToString();
            photoForCreationDTO.PublicId = uploadResult.PublicId;

            var photo = mapper.Map<Photo>(photoForCreationDTO);
            if (!userFromRepo.Photos.Any(y => y.IsMain))
                photo.IsMain = true;

            userFromRepo.Photos.Add(photo);

            if (await repo.SaveAll())
            {
                var photoToReturn = mapper.Map<PhotoForReturnDTO>(photo);
                return CreatedAtRoute("GetPhoto", new { userId = userId, id = photo.Id }, photoToReturn);
            }
            return BadRequest("Could not add the photo");
        }

        [HttpPost("{id}/setMain")]
        public async Task<IActionResult> SetMainPhoto(int userId, int id)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var user = await repo.GetUserById(userId);
            if (!user.Photos.Any(p => p.Id == id))
                return Unauthorized();

            var photoFromRepo = await repo.GetPhotoById(id);

            if (photoFromRepo.IsMain)
                return BadRequest("This is already a main photo");

            var currentMainPhoto = await repo.GetMainPhotoForUser(userId);
            currentMainPhoto.IsMain = false;
            photoFromRepo.IsMain = true;

            if (await repo.SaveAll())
            {
                return NoContent();
            }

            return BadRequest("Could not set photo to main");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoto(int userId, int id)
        {

            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var user = await repo.GetUserById(userId);
            if (!user.Photos.Any(p => p.Id == id))
                return Unauthorized();

            var photoFromRepo = await repo.GetPhotoById(id);

            if (photoFromRepo.IsMain)
                return BadRequest("You cant delete main photo.");
                    var cloudinaryDeleteParams = new DeletionParams(photoFromRepo.PublicId);
                var result = _cloudinary.Destroy(cloudinaryDeleteParams);
                if(result.Result == "ok"){
                    repo.DeletePhoto(photoFromRepo);
                }

                if(await repo.SaveAll())
                {
                    return Ok();
                }

                return BadRequest("Failed to delete the photo.");

        }

    }
}