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
    }
}
