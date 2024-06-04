using AutoMapper;
using FakeItEasy;
using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Test.Controller
{
    public class AnimalTest
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper;

        public AnimalTest(IAnimalRepository animalRepository, IMapper mapper)
        {
            _animalRepository = animalRepository;
            _mapper = mapper;
        }

        //[Fact]
        //public void AnimalController_GetAnimalOfUser_ReturnOk()
        //{
        //    //Arrange
        //    var animals = A.Fake<ICollection<Animal>>();
        //}
    }
}
