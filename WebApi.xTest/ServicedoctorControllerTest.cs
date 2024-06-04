using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VeterinarClinicApi.Controllers;
using VeterinarClinicApi.Dto;
using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Mapping;
using WebApi.xTest.FakeRepositories;


namespace WebApi.xTest
{
    public class ServicedoctorControllerTest
    {
        private readonly IMapper _mapper;
        private readonly IServicedoctorRepository _servicedoctorRepository;
        private readonly ServicedoctorController _servicedoctorController;

        public ServicedoctorControllerTest()
        {
            _servicedoctorRepository = new FakeServicedoctor();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mp =>
                {
                    mp.AddProfile(new MappingProfileDoctorsName());
                    mp.AddProfile(new MappingProfileServiceTitle());
                }
                );
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            _servicedoctorController = new ServicedoctorController(_servicedoctorRepository,_mapper);
        }

        [Fact]
        public void GetDoctors_ReturnOk()
        {
            int serviceId = 1;
            var item = _servicedoctorController.GetDoctors(serviceId);
            Assert.IsType<OkObjectResult>(item);
        }

        [Fact]
        public void GetServices_ReturnOk()
        {
            int doctorId = 1;
            var item = _servicedoctorController.GetServices(doctorId);
            Assert.IsType<OkObjectResult>(item);
        }
    }
}
