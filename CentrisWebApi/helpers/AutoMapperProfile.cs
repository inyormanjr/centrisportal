using System.Linq;
using AutoMapper;
using CentrisWebApi.DTO;
using CentrisWebApi.models.UserAgg;
using System;
using CentrisWebApi.models.Testimonials;

namespace CentrisWebApi.helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UsersForListDTO>()
            .ForMember(dest => dest.PhotoUrl, opt => 
                        opt.MapFrom(src => src.Photos.FirstOrDefault(x=> x.IsMain == true).Url))
            .ForMember(dest => dest.Age, opt => 
            opt.MapFrom(src => src.Birthday.Calculate()))
            .ForMember(dest => dest.FullName, opt => 
            opt.MapFrom(src => string.Format("{0} {1} {2}", src.FirstName, src.MiddleName, src.LastName)));
            
            CreateMap<UserForRegistrationDTO, User>();
            CreateMap<User, UserForDetailedDTO>()
            .ForMember(dest => dest.PhotoUrl, opt => 
                        opt.MapFrom(src => src.Photos.FirstOrDefault(x=> x.IsMain == true).Url))
            .ForMember(dest => dest.Age, opt => 
            opt.MapFrom(src => src.Birthday.Calculate()))
            .ForMember(dest => dest.FullName, opt => 
            opt.MapFrom(src => string.Format("{0} {1} {2}", src.FirstName, src.MiddleName, src.LastName)));;
            CreateMap<Photo, PhotoDetailedDTO>();
            CreateMap<UserForUpdateDTO, User>();
            CreateMap<Photo, PhotoForReturnDTO>();
            CreateMap<PhotoForCreationDTO, Photo>();
            
            CreateMap<TestimonialForAddDTO, Testimonial>();           
            CreateMap<TestimonialForUpdateDTO, Testimonial>(); 
            CreateMap<Testimonial, TestimonialForUpdateDTO>()
            .ForMember(des=> des.TestimonialByPhotoUrl, opt => 
               opt.MapFrom(src => src.TestimonyBy.Photos.Where(x=> x.IsMain).FirstOrDefault().Url))
            .ForMember(dest => dest.TestimonyBy, opt => opt.MapFrom(src =>  
            string.Format("{0} {1} {2}", src.TestimonyBy.FirstName, src.TestimonyBy.MiddleName, src.TestimonyBy.LastName))); 
        }
        
    }
}