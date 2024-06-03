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
    public class AnimalController : Controller
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper;
        public AnimalController(IAnimalRepository animalRepository, IMapper mapper)
        {
            _animalRepository = animalRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAnimalOfUserId")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Animal>))]
        [ProducesResponseType(400)]
        public IActionResult GetAnimalOfUser(int User)
        {
            if (!_animalRepository.OwnerExists(User))
                return NotFound($"Owner of {User} id not found.");

            var animal = 
                _mapper.Map<List<AnimalDto>>(
                    _animalRepository.GetAnimalsOfUserId(User));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(animal);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAnimal([FromBody] CreateAnimalDto create)
        {
            if (create == null)
                return BadRequest(ModelState);

            var animal =
                _animalRepository.GetAnimals()
                .FirstOrDefault(a =>
                    a.Name.Trim().ToLower() == create.Name.Trim().ToLower() &&
                    a.Owner == create.Owner
                    );

            if (animal != null)
            {
                ModelState.AddModelError("","Animal already exists.");
                return StatusCode(422, ModelState);
            }


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var creating =
                _mapper.Map<Animal>(create);

            if (! _animalRepository.CreateAnimal(creating))
            {
                ModelState.AddModelError("", "Something went wrong saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("UpdateAnimal")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUser(int animalId, [FromBody] AnimalDto update)
        {
            if (update == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_animalRepository.AnimalExists(animalId))
                return NotFound("Animal not found.");

            var uUp = _mapper.Map<Animal>(update);

            uUp.AnimalId = animalId;
           
            if (!_animalRepository.UpdateAnimal(uUp))
            {
                ModelState.AddModelError("", "Something went wrong updating.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
