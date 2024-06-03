using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Interfaces
{
    public interface IAnimalRepository
    {
        Animal GetAnimal(int animalId);
        ICollection<Animal> GetAnimalOfOwner(int? owner);
    }
}
