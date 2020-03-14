using System;
using CentrisWebApi.models.UserAgg;

namespace CentrisWebApi.models.Testimonials
{
    public class Testimonial
    {
        public Testimonial(){
            this.DateTimeAdded = DateTime.Now;
        }
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateTimeAdded { get; set; }
        public bool IsHearted {get;set;}
        public bool IsAproved {get;set;}        
        public User User {get;set;}
        public int UserId {get;set;}
        public User TestimonyBy {get;set;}
        public int TestimonyById {get;set;}
    }
}