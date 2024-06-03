using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly GoncharovaContext _context;
        public AnimalRepository(GoncharovaContext context) => _context = context;

        public Animal GetAnimal(int animalId)
        {
            return _context.Animals.First(a => a.AnimalId == animalId);
        }

        public ICollection<Animal> GetAnimalsOfUserId(int userId)
        {
            int? id = null;

            if (userId > -1)
            {
                id = userId;   
            }

            var animalCollection = 
                _context.Animals.Where(a => a.Owner == id).ToList();

            return animalCollection;
        }

        public bool OwnerExists(int userId)
        {
            return userId>-1?_context.Animals.Any(a => a.Owner == userId) : true;
        }
    }
}
