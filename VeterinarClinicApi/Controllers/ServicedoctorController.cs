using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinarClinicApi.Dto;
using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Models;
using VeterinarClinicApi.Repositories;

namespace VeterinarClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicedoctorController: Controller
    {
        private readonly IServicedoctorRepository _servicedoctor;
        private readonly IMapper _mapper;
        public ServicedoctorController(IServicedoctorRepository servicedoctor, IMapper mapper)
        {
            _servicedoctor = servicedoctor;
            _mapper = mapper;
        }

        [HttpGet("GetDoctors")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Servicedoctor>))]
        [ProducesResponseType(400)]
        public IActionResult GetDoctors(int serviceId)
        {
            if(! _servicedoctor.ServiceExists(serviceId))
                return NotFound($"Doctor that cam made service {serviceId} id not found.");

            var sd =
                _mapper.Map<List<DoctorNameDto>>(
                    _servicedoctor.GetDoctors(serviceId)
                    );
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(sd);
        }


        [HttpGet("GetServices")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Servicedoctor>))]
        [ProducesResponseType(400)]
        public IActionResult GetServices(int doctorId)
        {
            if (!_servicedoctor.DoctorExists(doctorId))
                return NotFound($"Services that make doctor of id {doctorId} id not found.");

            var sd =
                _mapper.Map<List<ServiceTitleDto>>(
                    _servicedoctor.GetServices(doctorId)
                    );

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(sd);
        }
    }
}
