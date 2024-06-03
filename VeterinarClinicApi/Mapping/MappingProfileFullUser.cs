using AutoMapper;
using VeterinarClinicApi.Dto;
using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Mapping
{
    public class MappingProfileFullUser : Profile
    {
        public MappingProfileFullUser() {
            CreateMap<User, UserDto>();
        }
    }
}
