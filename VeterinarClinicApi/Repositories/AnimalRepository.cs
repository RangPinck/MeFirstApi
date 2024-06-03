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

        public Animal GetAnimal(int animalId)
        {
            Animal animal =
                _context.Animals.FirstOrDefault(a => a.AnimalId == animalId);

            return animal;
        }

        public ICollection<Animal> GetAnimalOfOwner(int? ownerId)
        {
            var animal =
                _context.Animals.Where(a => a.Owner ==  ownerId).ToList();
            return animal;
        }
    }
}
