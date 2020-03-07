using System.ComponentModel.DataAnnotations;

namespace CentrisWebApi.DTO
{
    public class UserForRegistrationDTO
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }
        [Required]
        [StringLength(25,MinimumLength = 8, ErrorMessage= "Password length must not be lower than 8.")]
        public string Password { get; set; }
    }
}