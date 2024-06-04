using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Repositories;

namespace VCWebApi.xTest
{
    public class UserControllerTests
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        //public UserControllerTests()
        //{
        //    _userRepository = userRepository;
        //    _mapper = mapper;
        //}

        //[Fact]
        //public void Authorization_ReturnsOkResult()
        //{
        //    string email = "fedorova.margarita@gmail.com";
        //    string password = "354621";
        //    var okRes = _userRepository.Authorization(email, password);
        //    Assert.IsType<OkObjectResult>(okRes);
        //}
    }
}
