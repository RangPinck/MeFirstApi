using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VeterinarClinicApi.Controllers;
using VeterinarClinicApi.Dto;
using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Mapping;
using WebApi.xTest.FakeRepositories;

namespace WebApi.xTest
{
    public class AnimalControllerTest
    {
        private readonly IMapper _mapper;
        private readonly IAnimalRepository _animalRepository;
        private readonly AnimalController _animalController;

        public AnimalControllerTest()
        {
            _animalRepository = new FakeAnimalRepository();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mp =>
                {
                    mp.AddProfile(new MappingProfileAnimal());
                    mp.AddProfile(new MappingProfileCreateAnimal());
                }
                );
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            _animalController = new AnimalController(_animalRepository, _mapper);
        }

        [Fact]
        public void GetAnimalOfUser_ReturnOk()
        {
            int userId = -1;
            var item = _animalController.GetAnimalOfUser(userId);
            Assert.IsType<OkObjectResult>(item);
        }

        [Fact]
        public void CreateAnimal_ReturnOk()
        {
            CreateAnimalDto create = new CreateAnimalDto()
            {
                Name = "Грей",
                Age = 10,
                Breed = "Метис",
                Weight = 37,
                Description = "В нем столько любви, что держите поводок крепче.",
                Owner = 7
            };

            var item = _animalController.CreateAnimal(create);
            Assert.IsType<OkObjectResult>(item);
        }

        [Fact]
        public void UpdateUser_ReturnOk()
        {

            int animalId = 1;
            AnimalDto update = new AnimalDto()
            {
                Name = "Марципан",
                Age = 10,
                Breed = "Метис",
                Weight = 37,
                Description = "В нем столько любви, что держите поводок крепче.",
            };
            var item = _animalController.UpdateUser(1, update);
            Assert.IsType<NoContentResult>(item);
        }

        [Fact]
        public void DeleteAnimal_ReturnOk()
        {
            int animalId = 1;

            var item = _animalController.DeleteAnimal(1);
            Assert.IsType<NoContentResult>(item);
        }

    }
}
