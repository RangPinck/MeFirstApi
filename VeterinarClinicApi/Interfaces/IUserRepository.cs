using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Interfaces
{
    public interface IUserRepository
    {
        bool Authorization(string Email, string Password);

        bool UserExistsOfEmail(string Email);

        User GetUser(int UserId);

        bool UserExistsOfId(int UserId);
    }
}
