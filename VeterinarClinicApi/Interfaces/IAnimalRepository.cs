using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Interfaces
{
    public interface IAnimalRepository
    {
        //получение списка питомцев пользователя
        ICollection<Animal> GetAnimalsOfUserId(int userId);
        //получение данных животного
        Animal GetAnimal(int ainmalId);
        //проверка существования питомцев у пользователя
        bool OwnerExists(int userId);
        //создание питоца
        bool CreateAnimal(Animal animal);
        //обновление питоца
        bool UpdateAnimal(Animal animal);
        //Сохранение изменений
        bool DeleteAnimal(Animal animal);
        //Сохранение изменений
        bool Save();
        //получение списка питомцев 
        ICollection<Animal> GetAnimals();
        //проверка наличия питомца
        bool AnimalExists(int ainmalId);
    }
}
