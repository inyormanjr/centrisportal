using System.Linq;
using AutoMapper;
using CentrisWebApi.DTO;
using CentrisWebApi.models.UserAgg;
using System;

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

            CreateMap<User, UserForDetailedDTO>()
            .ForMember(dest => dest.PhotoUrl, opt => 
                        opt.MapFrom(src => src.Photos.FirstOrDefault(x=> x.IsMain == true).Url))
            .ForMember(dest => dest.Age, opt => 
            opt.MapFrom(src => src.Birthday.Calculate()))
            .ForMember(dest => dest.FullName, opt => 
            opt.MapFrom(src => string.Format("{0} {1} {2}", src.FirstName, src.MiddleName, src.LastName)));;
            CreateMap<Photo, PhotoDetailedDTO>();
            CreateMap<UserForUpdateDTO, User>();
        }
        
    }
}