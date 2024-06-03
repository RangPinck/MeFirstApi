using Microsoft.EntityFrameworkCore;
using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Repositories
{
    public class MedicalHistoryRepository : IMedicalHistoryOfAnimal
    {

        private readonly GoncharovaContext _context;
        public MedicalHistoryRepository(GoncharovaContext context) => _context = context;

        public bool AnimalExistInMedicalHistory(int animalId)
        {
            return _context.Medicalhistories.Any(a => a.Animal == animalId);
        }

        public ICollection<Medicalhistory> GetMedicalHistoryOfAnimal(int animalId)
        {
            return _context.Medicalhistories.Where(a => a.Animal == animalId)
                .Include(mh => mh.ServiceNavigation)
                .Include(mh => mh.DoctorNavigation)
                .ToList();
        }

        public bool CreateAppointment(Medicalhistory mh)
        {
            _context.Medicalhistories.Add(mh);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public ICollection<Medicalhistory> GetMedicalHistoryAll()
        {
            return _context.Medicalhistories.ToList();
        }
    }
}
