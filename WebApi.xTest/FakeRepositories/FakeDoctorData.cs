using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinarClinicApi.Models;

namespace WebApi.xTest.FakeRepositories
{
    public class FakeDoctorData
    {
        public List<Doctor> fakeDoctors()
        {
            return new List<Doctor>()
            {
                new Doctor()
                {
                    DoctorId = 1,
                    Surname = "Козырёва",
                    Name = "Милана",
                    Hiredate =  new DateOnly(2004,11,14),
                    Profession = "ветеринарный хирург",
                    Honors = "Опытный хирург, способный проводить операции на животных любой сложности."
                },
                new Doctor()
                {
                    DoctorId = 2,
                    Surname = "Юдин",
                    Name = "Денис",
                    Hiredate =  new DateOnly(2009,11,14),
                    Profession = "грумер",
                    Honors = "Специалист, совмещающий в себе роль парикмахера, стилиста и врача общей практики в уходе за домашними животными."
                },
                new Doctor()
                {
                    DoctorId = 3,
                    Surname = "Новикова",
                    Name = "Вера",
                    Hiredate =  new DateOnly(2013,9,19),
                    Profession = "ветеринарный терапевт",
                    Honors = "Опытный специалист, занимающийся диагностикой и лечением различных заболеваний у животных."
                },
                new Doctor()
                {
                    DoctorId = 4,
                    Surname = "Кириллов",
                    Name = "Фёдор",
                    Hiredate =  new DateOnly(2016,4,30),
                    Profession = "лаборант и процедурный медбрат",
                    Honors = "Специалист по оказанию медицинских процедур и сбору и обработке анализов."
                },
                 new Doctor()
                {
                    DoctorId = 5,
                    Surname = "Кузнецов",
                    Name = "Владислав",
                    Hiredate =  new DateOnly(2014,6,25),
                    Profession = "ветеринарный дерматолог",
                    Honors = "Эксперт по кожным заболеваниям у животных и специалист по их лечению."
                },
                 new Doctor()
                {
                    DoctorId = 6,
                    Surname = "Королёв",
                    Name = "Михаил",
                    Hiredate =  new DateOnly(2015,8,11),
                    Profession = "ветеринарный ЛОР-офтальмолог",
                    Honors = "Специализируется на диагностике и лечении болезней, возникающих в ушах, горле, носу и глазах у животных."
                },
            };
        }
    }
}
