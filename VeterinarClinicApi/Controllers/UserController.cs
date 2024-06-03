using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using VeterinarClinicApi.Another;
using VeterinarClinicApi.Dto;
using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Models;
using VeterinarClinicApi.Repositories;

namespace VeterinarClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("Authorization")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult Authorization(string Email, string Password)
        {
            try
            {
                new MailAddress(Email);
            }
            catch (FormatException)
            {
                return NotFound($"Email \"{Email}\" is not correct.");
            }

            if (!_userRepository.UserExistsOfEmail(Email))
                return NotFound($"User with email \"{Email}\" not found");

            var user =
                _mapper.Map<AuthorizationDto>(
                _userRepository.Authorization(Email.Trim(), Password.Trim()));

            if (!ModelState.IsValid)
                return BadRequest();

            if (user == null)
                return NotFound($"Password \"{Password}\" is not correct.");

            return Ok(user);
        }


        [HttpGet("UserData")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUserData(int UserId)
        {
            if(!_userRepository.UserExistsOfId(UserId))
                return NotFound($"User with Id \"{UserId}\" not found");

            var user =
                _mapper.Map<UserDto>(
                    _userRepository.GetUser(UserId)
                    );

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] CreateUserDto create)
        {
            if (create == null)
                return BadRequest(ModelState);

            try
            {
                new MailAddress(create.Email);
            }
            catch (FormatException)
            {
                ModelState.AddModelError("", "Email not correct.");
                return StatusCode(422, ModelState);
            }


            var animal =
                _userRepository.GetUsers()
                .FirstOrDefault(u =>
                u.Email.Trim().ToLower() == create.Email.Trim().ToLower() ||
                u.Phone == create.Phone
                );

            if (animal != null)
            {
                ModelState.AddModelError("", "User already exists.");
                return StatusCode(422, ModelState);
            }


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var creating =
                _mapper.Map<User>(create);

            creating.Password = md5.hashPasswordToMd5(creating.Password);

            if (!_userRepository.CreateUser(creating))
            {
                ModelState.AddModelError("", "Something went wrong saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}
