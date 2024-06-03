using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Interfaces
{
    public interface IAnimalRepository
    {
        ICollection<Animal> GetAnimalsOfUserId(int userId);

        bool OwnerExists(int userId);
    }
}
