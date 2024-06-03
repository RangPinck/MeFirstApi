using AutoMapper;
using VeterinarClinicApi.Dto;
using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Mapping
{
    public class MappingProfileAuthorization : Profile
    {
        public MappingProfileAuthorization()
        {
            CreateMap<User, AuthorizationDto>();
        }
    }
}
