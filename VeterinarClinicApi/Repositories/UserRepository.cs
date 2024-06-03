using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GoncharovaContext _context;

        public UserRepository(GoncharovaContext context) => _context = context;

        public bool Authorization(string Email, string Password)
        {
            return _context.Users.Any(u => u.Email == Email);
        }

        public User GetUser(int UserId)
        {
            throw new NotImplementedException();
        }

        public bool UserExistsOfEmail(string Email)
        {
            return _context.Users.Any(u => u.Email == Email);
        }

        public bool UserExistsOfId(int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
