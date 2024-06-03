using AutoMapper;
using VeterinarClinicApi.Dto;
using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Mapping
{
    public class MappingProfileAnimal : Profile
    {
        public MappingProfileAnimal()
        {
            CreateMap<Animal, AnimalDto>();
            CreateMap<AnimalDto, Animal>();
        }
    }
}
