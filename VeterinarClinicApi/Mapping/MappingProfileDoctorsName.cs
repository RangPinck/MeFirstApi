using AutoMapper;
using VeterinarClinicApi.Dto;
using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Mapping
{
    public class MappingProfileDoctorsName : Profile
    {
        public MappingProfileDoctorsName() {
            CreateMap<Servicedoctor, DoctorNameDto>()
                .ForMember(d => d.Name,
                opt => opt.MapFrom(dDto => dDto.Doctor.Surname + 
                " " + dDto.Doctor.Name.Substring(0,1)));
        }
    }
}
