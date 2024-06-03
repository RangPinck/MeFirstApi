using VeterinarClinicApi.Another;
using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GoncharovaContext _context;

        public UserRepository(GoncharovaContext context) => _context = context;

        //авторизация пользователя
        public User Authorization(string Email, string Password)
        {
            string hashPassword = md5.hashPasswordToMd5(Password);
            return _context.Users.FirstOrDefault(u => u.Email == Email && u.Password == hashPassword);
        }
        //получение данных
        public User GetUser(int UserId)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == UserId);
        }
        //проверка существования пользователя по почте
        public bool UserExistsOfEmail(string Email)
        {
            return _context.Users.Any(u => u.Email == Email);
        }
        //проверка существования пользователя по id
        public bool UserExistsOfId(int UserId)
        {
            return _context.Users.Any(u => u.UserId == UserId);
        }
    }
}
