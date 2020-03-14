using System;

namespace CentrisWebApi.models.UserAgg
{
    public class Photo
    {
        public Photo()
        {
            this.DateAdded = DateTime.Now;
        }

        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public string PublicId {get;set;}
        public User User {get;set;}
        public int UserId {get;set;}
    }
}