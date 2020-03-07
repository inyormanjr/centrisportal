using CentrisWebApi.models.UserProfileAgg;

namespace CentrisWebApi.models.UserAgg
{
    public class User
    {
        public User()
        {

        }

        public int Id { get; set; }
        public string username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt {get;set;}
        public UserType UserType {get;set;}


        public void SetHashAndSalt(byte[] passwordhash, byte[] passwordsalt)
        {
            this.PasswordHash = passwordhash;
            this.PasswordSalt = passwordsalt;
        }
        
    }
}