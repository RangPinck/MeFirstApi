using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarClinicApi.Interfaces;
using VeterinarClinicApi.Models;

namespace WebApi.xTest.FakeRepositories
{
    public class FakeServices
    {
        private readonly List<Service> _fakeService;
        public FakeServices()
        {
            _fakeService = new List<Service>()
            {
                new Service(){
                    ServiceId = 1,
                    Title = "Клинический осмотр",
                    Description = "Термометрия, аускультация, пальпация, назначение лечения",
                    Price = 500,
                },
                new Service(){
                    ServiceId = 7,
                    Title = "Анализ крови",
                    Description = "Проведение анализа крови питомца по 1 показателю",
                    Price = 200,
                },
                new Service(){
                    ServiceId = 11,
                    Title = "Гигиеническая стрижка",
                    Description = "Гигиеническая стрижка любого животного",
                    Price = 800,
                },
            };
        }
    }
}
