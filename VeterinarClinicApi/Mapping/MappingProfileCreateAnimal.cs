using AutoMapper;
using VeterinarClinicApi.Dto;
using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Mapping
{
    public class MappingProfileCreateAnimal : Profile
    {
        public MappingProfileCreateAnimal() {
            CreateMap<CreateAnimalDto, Animal>();
        }
    }
}
