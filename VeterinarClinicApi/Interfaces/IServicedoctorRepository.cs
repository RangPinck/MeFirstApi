using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Interfaces
{
    public interface IServicedoctorRepository
    {
        ICollection<Servicedoctor> GetServicedoctors();
    }
}
