using AutoMapper;
using VeterinarClinicApi.Dto;
using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Mapping
{
    public class MappingProfileAnimalMedicarHistory : Profile
    {
        public MappingProfileAnimalMedicarHistory() {
            CreateMap<Medicalhistory, AnimalMedicatHistoryDto>()
                .ForMember(mh => mh.KardId,
                opt => opt.MapFrom(mhDto => mhDto.KardId))
                 .ForMember(mh => mh.Visitingtime,
                opt => opt.MapFrom(mhDto => mhDto.Visitingtime))
                 .ForMember(mh => mh.Service,
                opt => opt.MapFrom(mhDto => mhDto.ServiceNavigation.Title))
                 .ForMember(mh => mh.Doctor,
                opt => opt.MapFrom(mhDto => mhDto.DoctorNavigation.Surname + " " + mhDto.DoctorNavigation.Name.Substring(0, 1)));
        }
    }
}
