using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using VeterinarClinicApi.Controllers;
using VeterinarClinicApi.Dto;
using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Mapping;
using VeterinarClinicApi.Models;
using WebApi.Test.FakeRepositories;

namespace WebApi.Test
{
    public class UserControllerTests
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly UserController _userController;

        public UserControllerTests()
        {
            _userRepository = new FakeUserRepository();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mp =>
                {
                    mp.AddProfile(new MappingProfileAuthorization());
                    mp.AddProfile(new MappingProfileCreateUser());
                    mp.AddProfile(new MappingProfileFullUser());
                }
                );
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            _userController = new UserController(_userRepository, _mapper);
        }

        [Fact]
        public void Authorization_ReturnOk()
        {
            string email = "fedorova.margarita@gmail.com";
            string password = "354621";
            var item = _userController.Authorization(email, password);
            Assert.IsType<OkObjectResult>(item);
        }

        [Fact]
        public void CreateUser_ReturnOk()
        {
            CreateUserDto cherlovek = new CreateUserDto()
            {
                Surname = "�������",
                Name = "�����",
                Phone = "+ 7 (952)668-31-26",
                Email = "efimova.sofia@gmail.com",
                Password = "ee58ff29c0d91a81955f2922097c56c6"
            };

            var item = _userController.CreateUser(cherlovek);
            Assert.IsType<OkObjectResult>(item);
        }

        [Fact]
        public void GetUserData_ReturnOk()
        {
            int userId = 1;
            var item = _userController.GetUserData(1);
            Assert.IsType<OkObjectResult>(item);
        }

        [Fact]
        public void UpdateUser_NoContent()
        {

            int userId = 1;
            CreateUserDto upU = new CreateUserDto()
            {
                Surname = "����������",
                Name = "�����",
                Phone = "+ 7 (919)459-57-74",
                Email = "emelyanova.veronika@gmail.com",
                Password = "657"
            };

            var item = _userController.UpdateUser(1, upU);
            Assert.IsType<NoContentResult>(item);
        }

        [Fact]
        public void DeleteUser_NoContent()
        {

            int userId = 1;

            var item = _userController.DeleteUser(1);
            Assert.IsType<NoContentResult>(item);
        }

    }
}