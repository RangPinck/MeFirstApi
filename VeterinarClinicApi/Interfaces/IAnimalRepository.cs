using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Interfaces
{
    public interface IAnimalRepository
    {
        ICollection<Animal> GetAnimals(int? Owner);
    }
}
