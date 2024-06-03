using Microsoft.EntityFrameworkCore;
using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Repositories
{
    public class ServicedoctorRepository : IServicedoctorRepository
    {
        private readonly GoncharovaContext _context;

        public ServicedoctorRepository(GoncharovaContext context)
        {
            _context = context;
        }

        public ICollection<Servicedoctor> GetServicedoctors()
        {
            var servicedoctorList =
                _context.Servicedoctors.ToList();
            return servicedoctorList;
        }
    }
}
