using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarClinicApi.Controllers;
using VeterinarClinicApi.Dto;
using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Mapping;
using WebApi.xTest.FakeRepositories;

namespace WebApi.xTest
{
    public class MedicalhistoryControllerTest
    {
        private readonly IMapper _mapper;
        private readonly IMedicalHistoryOfAnimal _medicalhistoryRepository;
        private readonly IServicedoctorRepository _servd;
        private readonly IAnimalRepository _animal;
        private readonly MedicalHistoryOfAnimalController _medicalhistoryController;

        public MedicalhistoryControllerTest()
        {
            _medicalhistoryRepository = new FakeMedicalhystory();
            _animal = new FakeAnimalRepository();
            _servd = new FakeServicedoctor();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mp =>
                {
                    mp.AddProfile(new MappingProfileAnimalMedicarHistory());
                    mp.AddProfile(new MappingProfileCreateAppointment());
                }
                );
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            _medicalhistoryController = new MedicalHistoryOfAnimalController(_medicalhistoryRepository, _mapper, _servd, _animal);
        }

        [Fact]
        public void GetMedicalHistoryOfAnimal_ReturnOk()
        {
            int animalId = 7;
            var item = _medicalhistoryController.GetMedicalHistoryOfAnimal(animalId);
            Assert.IsType<OkObjectResult>(item);
        }

        [Fact]
        public void CreateAppintment_ReturnOk()
        {
            CreateMedicalHistoryDto create = new CreateMedicalHistoryDto(){
                Animal = 1,
                Visitingtime = DateTime.Now,
                Doctor = 3,
                Service = 1
            };
            var item = _medicalhistoryController.CreateAppintment(create);
            Assert.IsType<OkObjectResult>(item);
        }

    }
}
