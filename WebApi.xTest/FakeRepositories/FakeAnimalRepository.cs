
using Microsoft.EntityFrameworkCore;
using VeterinarClinicApi.Another;
using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Models;

namespace WebApi.xTest.FakeRepositories
{
    public class FakeAnimalRepository : IAnimalRepository
    {
        private readonly List<Animal> _fakeAnimals;

        public FakeAnimalRepository()
        {
            _fakeAnimals = new List<Animal>()
            {
                new Animal(){
                    AnimalId = 1,
                    Name = "Луна",
                    Age = 3,
                    Breed = "Британская короткошёрстная",
                    Weight = 4,
                    Description = "Луна - настоящая королева на четырёх лапах. Её шелковистая шерсть, изящные усы и мягкий мурлык привлекают внимание всех вокруг. Луна обожает ласки и общество людей, игры и длинные тихие дрёмы на солнышке. Она ищет тёплый дом, где её будут любить и баловать вкусным кормом.",
                    Owner = null
                },
                new Animal(){
                    AnimalId = 2,
                    Name = "Лисса",
                    Age = 5,
                    Breed = "Отсутствует",
                    Weight = 5,
                    Description = "Милая и ласковая, будет любить вас, если вы ее защищаете",
                    Owner = 7
                },
                new Animal(){
                    AnimalId = 3,
                    Name = "Тайшет",
                    Age = 11,
                    Breed = "Скоттиш-страйт",
                    Weight = 6,
                    Description = "Не любит никого, но вы можете попасть под его любовный порыв.",
                    Owner = 7
                },
            };
        }

        public bool AnimalExists(int ainmalId)
        {
            return _fakeAnimals.Any(a => a.AnimalId == ainmalId);
        }

        public bool CreateAnimal(Animal animal)
        {
            _fakeAnimals.Add(animal);
            return Save();
        }

        public bool DeleteAnimal(Animal animal)
        {
            _fakeAnimals.Remove(animal);
            return Save();
        }

        public Animal GetAnimal(int ainmalId)
        {
            return _fakeAnimals.FirstOrDefault(u => u.AnimalId == ainmalId);
        }

        public ICollection<Animal> GetAnimals()
        {
            return _fakeAnimals.ToList();
        }

        public ICollection<Animal> GetAnimalsOfUserId(int userId)
        {
            int? id = null;

            if (userId > -1)
            {
                id = userId;
            }

            var animalCollection =
                _fakeAnimals.Where(a => a.Owner == id).ToList();

            return animalCollection;
        }

        public bool OwnerExists(int userId)
        {
            return userId > -1 ? _fakeAnimals.Any(a => a.Owner == userId) : true;
        }

        public bool Save()
        {
            return true;
        }

        public bool UpdateAnimal(Animal animal)
        {
            int index = _fakeAnimals.FindIndex(u => u.AnimalId == animal.AnimalId);
            if (index != -1)
                _fakeAnimals[index] = animal;
            return Save();
        }
    }
}
