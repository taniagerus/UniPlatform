using AutoMapper;
using UniPlatform.Authorization;
using UniPlatform.DB.Entities;
using UniPlatform.ViewModels;

namespace UniPlatform.ProfileMappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, RegistrationRequest>().ReverseMap();
        }
    }
}
