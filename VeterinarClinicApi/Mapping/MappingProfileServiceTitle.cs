using AutoMapper;
using VeterinarClinicApi.Dto;
using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Mapping
{
    public class MappingProfileServiceTitle : Profile
    {
        public MappingProfileServiceTitle()
        {
            CreateMap<Servicedoctor,ServiceTitleDto>()
                .ForMember(s => s.Title,
                opt => opt.MapFrom(sDto => sDto.Service.Title));
        }
    }
}
