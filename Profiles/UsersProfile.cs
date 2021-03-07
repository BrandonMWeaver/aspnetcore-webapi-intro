using AutoMapper;

using AspNetCoreWebApiIntro.Dtos;
using AspNetCoreWebApiIntro.Models;

namespace AspNetCoreWebApiIntro.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<User, UserUpdateDto>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}
