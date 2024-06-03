using Microsoft.AspNetCore.Mvc;
using VeterinarClinicApi.Dto;
using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicedoctorController : Controller
    {
        private readonly IServicedoctorRepository _servicedoctorRepository;

        public ServicedoctorController(IServicedoctorRepository servicedoctorRepository)
        {
            _servicedoctorRepository = servicedoctorRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ServicedoctorDto>))]
        public IActionResult GetServicedoctor()
        {
            var servicedoctor = _servicedoctorRepository.GetServicedoctors();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(servicedoctor);
        }
    }
}
