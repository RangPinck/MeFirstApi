using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Models;

namespace WebApi.xTest.FakeRepositories
{
    public class FakeMedicalhystory : IMedicalHistoryOfAnimal
    {
        private readonly List<Medicalhistory> _fakeAMedicalhistory;

        public FakeMedicalhystory()
        {
            _fakeAMedicalhistory = new List<Medicalhistory>()
            {
                new Medicalhistory()
                {
                    KardId = 1,
                    Animal = 7,
                    Visitingtime = new DateTime(2024,05,25,9,50, 0,0),
                    Doctor = 3,
                    Service = 1
                },
                new Medicalhistory()
                {
                    KardId = 2,
                    Animal = 7,
                    Visitingtime = new DateTime(2023,11,20,16,0, 0,0),
                    Doctor = 4,
                    Service = 7
                },
                new Medicalhistory()
                {
                    KardId = 3,
                    Animal = 7,
                    Visitingtime = new DateTime(2024,04,04,19,00, 0,0),
                    Doctor = 2,
                    Service = 11
                },
            };
        }

        public bool AnimalExistInMedicalHistory(int animalId)
        {
            return _fakeAMedicalhistory.Any(a => a.Animal == animalId);
        }

        public bool CreateAppointment(Medicalhistory mh)
        {
            _fakeAMedicalhistory.Add(mh);
            return Save();
        }

        public ICollection<Medicalhistory> GetMedicalHistoryAll()
        {
            return _fakeAMedicalhistory.ToList();
        }

        public ICollection<Medicalhistory> GetMedicalHistoryOfAnimal(int animalId)
        {
            return _fakeAMedicalhistory.Where(a => a.Animal == animalId).ToList();
        }

        public bool Save()
        {
            return true;
        }
    }
}
