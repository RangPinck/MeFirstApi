using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Interfaces
{
    public interface IAnimalRepository
    {
        //получение списка питомцев пользователя
        ICollection<Animal> GetAnimalsOfUserId(int userId);
        //проверка существования питомцев у пользователя
        bool OwnerExists(int userId);
    }
}
