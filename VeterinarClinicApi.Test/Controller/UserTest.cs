using AutoFixture;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using VeterinarClinicApi.Controllers;
using VeterinarClinicApi.Dto;
using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Test.Controller
{

    public class UserTest
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private Fixture _fixture;
        private UserController _userController;
        private readonly IMapper _mapper;

        public UserTest()
        {
            _fixture = new Fixture();
            _userRepositoryMock = new Mock<IUserRepository>();
        }


        [Fact]
        public void UserController_Authorization_ReturnOk()
        {

            var authUser = _fixture.Create<User>();
            _userRepositoryMock.Setup(
                repo => repo.Authorization("", "")
                ).Returns(authUser);

            _userController = new UserController(_userRepositoryMock.Object, _mapper);

            var result = _userController.Authorization("", "");

            var obj = result as ObjectResult;

            Assert.Equal(200, obj.StatusCode);
        }
    }
}
