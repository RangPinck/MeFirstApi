using AutoMapper;
using VeterinarClinicApi.Dto;
using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Mapping
{
    public class MappingProfileCreateUser : Profile
    {
        public MappingProfileCreateUser()
        {
            CreateMap<CreateUserDto, User>();
        }
    }
}
