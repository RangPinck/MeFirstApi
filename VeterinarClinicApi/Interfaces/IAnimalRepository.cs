using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Interfaces
{
    public interface IAnimalRepository
    {
        //получение списка питомцев пользователя
        ICollection<Animal> GetAnimalsOfUserId(int userId);
        //проверка существования питомцев у пользователя
        bool OwnerExists(int userId);
        //создание питоца
        bool CreateAnimal(Animal animal);
        //Сохранение изменений
        bool Save();
        //получение списка питомцев 
        ICollection<Animal> GetAnimals();
    }
}
