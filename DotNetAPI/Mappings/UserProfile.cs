using AutoMapper;
using DotNetAPI.Dtos;
using DotNetAPI.Models;

namespace DotNetAPI.Mappings;

  public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Define the mapping from UserToAddDto to User
            CreateMap<UserToAddDto, User>();
        }
    }
