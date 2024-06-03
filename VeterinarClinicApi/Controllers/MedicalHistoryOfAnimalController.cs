using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VeterinarClinicApi.Dto;
using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalHistoryOfAnimalController : Controller
    {
        private readonly IMedicalHistoryOfAnimal _medical;
        private readonly IMapper _mapper;
        public MedicalHistoryOfAnimalController(IMedicalHistoryOfAnimal medical, IMapper mapper)
        {
            _medical = medical;
            _mapper = mapper;
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
    }
}
