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
    public class FakeServicedoctor : IServicedoctorRepository
    {
        private readonly List<Servicedoctor> _fakeServicedoctor;

        public FakeServicedoctor()
        {
            _fakeServicedoctor = new List<Servicedoctor>()
            {
                new Servicedoctor()
                {
                    ServiceId = 1,
                    DoctorId = 1
                },
                new Servicedoctor()
                {
                    ServiceId = 11,
                    DoctorId = 2
                },
                new Servicedoctor()
                {
                    ServiceId = 12,
                    DoctorId = 2
                },
                new Servicedoctor()
                {
                    ServiceId = 1,
                    DoctorId = 3
                },
                new Servicedoctor()
                {
                    ServiceId = 7,
                    DoctorId = 4
                },
                new Servicedoctor()
                {
                    ServiceId = 9,
                    DoctorId = 4
                },
                new Servicedoctor()
                {
                    ServiceId = 4,
                    DoctorId = 4
                },
                new Servicedoctor()
                {
                    ServiceId = 5,
                    DoctorId = 4
                },
                 new Servicedoctor()
                {
                    ServiceId = 6,
                    DoctorId = 4
                },
                 new Servicedoctor()
                {
                    ServiceId = 1,
                    DoctorId = 5
                },
                 new Servicedoctor()
                {
                    ServiceId = 7,
                    DoctorId = 5
                },
                 new Servicedoctor()
                {
                    ServiceId = 1,
                    DoctorId = 6
                }
            };
        }

        public bool DoctorExists(int doctorId)
        {
            return _fakeServicedoctor.Any(d => d.DoctorId == doctorId);
        }

        public ICollection<Servicedoctor> GetDoctors(int serviceId)
        {
            return _fakeServicedoctor.Where(d => d.ServiceId == serviceId).ToList();
        }

        public ICollection<Servicedoctor> GetServices(int doctorId)
        {
            return _fakeServicedoctor.Where(d => d.DoctorId == doctorId).ToList();
        }

        public bool ServiceExists(int serviceId)
        {
            return _fakeServicedoctor.Any(s => s.ServiceId == serviceId);
        }
    }
}
