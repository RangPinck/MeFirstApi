
using Microsoft.EntityFrameworkCore;
using VeterinarClinicApi.Another;
using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Models;

namespace WebApi.Test.FakeRepositories
{
    public class FakeUserRepository : IUserRepository
    {
        private readonly List<User> _fakeUsers;

        public FakeUserRepository()
        {
            _fakeUsers = new List<User>()
            {
                new User()
                {
                    UserId = 1,
                    Surname = "Фёдорова",
                    Name = "Маргарита",
                    Phone = "+ 7 (939)703-65-78",
                    Email = "fedorova.margarita@gmail.com",
                    Password = "af933f7597f69245497568b7e82b94b6"
                },
                new User()
                {
                    UserId = 2,
                    Surname = "Емельянова",
                    Name = "Вероника",
                    Phone = "+ 7 (919)459-57-74",
                    Email = "emelyanova.veronika@gmail.com",
                    Password = "8d9652ef48d71a69f37ec6b9662c3101"
                },
                new User()
                {
                    UserId = 7,
                    Surname = "Елизаров",
                    Name = "Дмитрий",
                    Phone = "+ 7 (900)863-47-62",
                    Email = "elizarov.dmitry@gmail.com",
                    Password = "bd4ec2bde33ad7d07ea2c7dede428634"
                }
            };
        }

        public User Authorization(string Email, string Password)
        {
            string hashPassword = md5.hashPasswordToMd5(Password);
            return _fakeUsers.FirstOrDefault(u => u.Email == Email && u.Password == hashPassword);
        }

        public bool CreateUser(User user)
        {
            _fakeUsers.Add(user);
            return Save();
        }

        public bool DeleteUser(User user)
        {
            _fakeUsers.Remove(user);
            return Save();
        }

        public User GetUser(int UserId)
        {
            return _fakeUsers.FirstOrDefault(u => u.UserId == UserId);
        }

        public ICollection<User> GetUsers()
        {
            return _fakeUsers;
        }

        public bool Save()
        {
            return true;
        }

        public bool UpdateUser(User user)
        {
            _fakeUsers[user.UserId] = user;
            return Save();
        }

        public bool UserExistsOfEmail(string Email)
        {
            return _fakeUsers.Any(u => u.Email == Email);
        }

        public bool UserExistsOfId(int UserId)
        {
            return _fakeUsers.Any(u => u.UserId == UserId);
        }
    }
}
