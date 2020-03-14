using System;
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
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string MiddleName {get;set;}
        public string LastName {get;set;}
        public DateTime Birthday {get;set;}
        public string Address { get; set; }
        public int ContactNumber { get; set; }
    }
}