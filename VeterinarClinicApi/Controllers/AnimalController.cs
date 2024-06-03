using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VeterinarClinicApi.Dto;
using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Models;

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
    }
}
