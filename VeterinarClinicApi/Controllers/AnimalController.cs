using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController
    {
        public readonly IAnimalRepository _animalRepository;

        public AnimalController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        //[HttpGet]
        //[ProducesResponseType(200, Type = typeof(IEnumerable<Animal>))]
        //public IAnimalRepository GetAnimalRepository(int? Owner) { 
        //    var animal = _animalRepository.GetAnimals(Owner);

        //    return Ok(animal);
        //}
    }
}
