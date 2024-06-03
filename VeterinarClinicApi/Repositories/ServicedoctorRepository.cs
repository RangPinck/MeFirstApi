using Microsoft.EntityFrameworkCore;
using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Repositories
{
    public class ServicedoctorRepository : IServicedoctorRepository
    {
        private readonly GoncharovaContext _context;
        public ServicedoctorRepository(GoncharovaContext context) => _context = context;

        public bool DoctorExists(int doctorId)
        {
            return _context.Servicedoctors.Any(d => d.DoctorId == doctorId);
        }

        public ICollection<Servicedoctor> GetDoctors(int serviceId)
        {
            return _context.Servicedoctors.Where(d => d.ServiceId == serviceId)
                .Include(d => d.Doctor)
                .ToList();
        }

        public ICollection<Servicedoctor> GetServices(int doctorId)
        {
            return _context.Servicedoctors.Where(d => d.DoctorId == doctorId)
                .Include(d => d.Service)
                .ToList();
        }

        public bool ServiceExists(int serviceId)
        {
            return _context.Servicedoctors.Any(s => s.ServiceId == serviceId);
        }
    }
}
