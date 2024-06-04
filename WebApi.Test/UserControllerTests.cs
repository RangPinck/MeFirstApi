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

    [TestClass]
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

        [TestMethod]
        public void Authorization_IsNotNull()
        {
            string email = "fedorova.margarita@gmail.com";
            string password = "354621";
            var item = _userController.Authorization(email, password);
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void CreateUser_IsTrue()
        {
            CreateUserDto cherlovek = new CreateUserDto()
            {
                Surname = "Ефимова",
                Name = "Софья",
                Phone = "+ 7 (952)668-31-26",
                Email = "efimova.sofia@gmail.com",
                Password = "ee58ff29c0d91a81955f2922097c56c6"
            };

            var item = _userController.CreateUser(cherlovek);
            Assert.IsTrue(item != null);
        }

    }
}