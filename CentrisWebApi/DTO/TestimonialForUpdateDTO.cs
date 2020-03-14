using System;

namespace CentrisWebApi.DTO
{
    public class TestimonialForUpdateDTO
    {
        public string Message { get; set; }
        public DateTime DateTimeAdded { get; set; }
        public bool IsHearted {get;set;}   
        public int UserId {get;set;}
        public int TestimonyById {get;set;}
        public string TestimonyBy {get;set;}
        public string TestimonialByPhotoUrl {get; set;}

    }
}