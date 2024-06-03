using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using VeterinarClinicApi.Dto;
using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Models;

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
    }
}
