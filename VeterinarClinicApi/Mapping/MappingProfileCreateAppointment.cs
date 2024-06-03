using AutoMapper;
using VeterinarClinicApi.Dto;
using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Mapping
{
    public class MappingProfileCreateAppointment : Profile
    {
        public MappingProfileCreateAppointment()
        {
            CreateMap<CreateMedicalHistoryDto, Medicalhistory>();
        }
    }
}
