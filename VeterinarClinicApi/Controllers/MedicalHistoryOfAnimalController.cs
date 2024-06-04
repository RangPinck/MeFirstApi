using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using VeterinarClinicApi.Dto;
using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Models;
using VeterinarClinicApi.Repositories;

namespace VeterinarClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalHistoryOfAnimalController : Controller
    {
        private readonly IMedicalHistoryOfAnimal _medical;
        private readonly IServicedoctorRepository _servd;
        private readonly IAnimalRepository _animal;
        private readonly IMapper _mapper;
        public MedicalHistoryOfAnimalController(IMedicalHistoryOfAnimal medical, IMapper mapper, IServicedoctorRepository servd, IAnimalRepository animal)
        {
            _medical = medical;
            _mapper = mapper;
            _servd = servd;
            _animal = animal;
        }

        [HttpGet("Get medical history of animal")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Medicalhistory>))]
        [ProducesResponseType(400)]
        public IActionResult GetMedicalHistoryOfAnimal(int animalId)
        {
            if (!_medical.AnimalExistInMedicalHistory(animalId))
                return NotFound($"History of animal \"{animalId}\" id not found.");

            var history =
                _mapper.Map<List<AnimalMedicatHistoryDto>>(
                   _medical.GetMedicalHistoryOfAnimal(animalId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(history);
        }

        [HttpPost("CreateAppintment")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAppintment([FromBody] CreateMedicalHistoryDto create)
        {
            if (create == null)
                return BadRequest(ModelState);

            if (!_servd.DoctorExists(create.Doctor))
            {
                return NotFound($"Doctor that can made service {create.Service} id not found.");
            }

            if (!_servd.ServiceExists(create.Service))
            {
                return NotFound($"Services that make doctor of id {create.Doctor} id not found.");
            }

            if (!_animal.AnimalExists(create.Animal))
            {
                return NotFound($"Animal of id {create.Animal} id not found.");
            }

            var mh =
                _medical.GetMedicalHistoryAll()
                .FirstOrDefault(
                    h =>
                    h.Animal == create.Animal &&
                    h.Visitingtime == create.Visitingtime &&
                    h.Service == create.Service &&
                    h.Doctor == create.Doctor
                    );

            if (mh != null)
            {
                ModelState.AddModelError("", "Appointmetnt already exists.");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var creating =
                _mapper.Map<Medicalhistory>(create);

           // creating.Visitingtime = creating.Visitingtime.ToUniversalTime();

            if (!_medical.CreateAppointment(creating))
            {
                ModelState.AddModelError("", "Something went wrong saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}
