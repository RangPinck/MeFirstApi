using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly GoncharovaContext _context;

        public AnimalRepository(GoncharovaContext context)
        {
            _context = context;
        }

        public ICollection<Animal> GetAnimals(int? Owner)
        {
            var animalList =
                _context.Animals.Where(a => a.Owner == Owner).ToList();

            return animalList;
        }
    }
}
