using System;
using System.Collections.Generic;
using CentrisWebApi.models.UserAgg;

namespace CentrisWebApi.DTO
{
    public class UserForDetailedDTO
    {
        public int Id { get; set; }
        public string username { get; set; }
        public UserType UserType {get;set;}
         public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string FullName {get;set;}
        public string BaptismalName { get; set; }
        public DateTime Birthday { get; set; }
        public int Age {get;set;}
        public Gender Gender {get;set;}
        public DateTime SurvivalDate { get; set; }
        public string Address { get; set; }
        public DateTime LastActive { get; set; }
        public DateTime AccountCreated { get; set; }

         public int ContactNumber { get; set; }
        public string FaceBookUrl {get;set;}
        public string HighSchoolAttended { get; set; }
        public int HighSchoolYearGraduated {get;set;}

        public string CollegeAttended {get;set;}
        public int CollegeYearGraduated {get;set;}
        public string DegreeName {get;set;}

        public string JobName {get;set;}
        public string JobAddress {get;set;}
        public string JobDescrtion {get;set;}

        public int Height {get;set;}
        public int Weight {get;set;}
        public string EyeColor {get;set;}
        public string PhotoUrl {get;set;}
        public ICollection<PhotoDetailedDTO> Photos {get;set;}

    }
}