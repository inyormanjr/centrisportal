using System;

namespace CentrisWebApi.models.UserProfileAgg
{
    public class UserProfile
    {
        public UserProfile()
        {

        }


        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string BaptismalName { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime SurvivalDate { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
        
    }
}