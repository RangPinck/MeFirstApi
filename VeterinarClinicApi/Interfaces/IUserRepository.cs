using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Interfaces
{
    public interface IUserRepository
    {
        //авторизация пользователя
        User Authorization(string Email, string Password);
        //проверка существования пользователя по почте
        bool UserExistsOfEmail(string Email);
        //получение данных
        User GetUser(int UserId);
        //проверка существования пользователя по id
        bool UserExistsOfId(int UserId);
        //получение спииска пользователей
        ICollection<User> GetUsers();
        //создание пользователя
        bool CreateUser(User user);
        //обвновление
        bool UpdateUser(User user);
        //Сохранение изменений
        bool Save();
    }
}
