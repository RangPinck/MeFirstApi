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
            return _context.Animals.FirstOrDefault(u => u.AnimalId == animalId);
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

        public bool CreateAnimal(Animal animal)
        {
            _context.Animals.Add(animal);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public ICollection<Animal> GetAnimals()
        {
            return _context.Animals.ToList();
        }

        public bool AnimalExists(int ainmalId)
        {
            return _context.Animals.Any(a => a.AnimalId == ainmalId);
        }

        public bool UpdateAnimal(Animal animal)
        {
            _context.Animals.Update(animal);
            return Save();
        }

        public bool DeleteAnimal(Animal animal)
        {
            _context.Animals.Remove(animal);
            return Save();
        }
    }
}
