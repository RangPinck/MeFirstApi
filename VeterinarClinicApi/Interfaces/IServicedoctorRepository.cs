using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Interfaces
{
    public interface IServicedoctorRepository
    {
        //проверка на наличие услуги по id
        bool ServiceExists(int serviceId);
        //проверка на наличие доктора, способного оказать услугу
        bool DoctorExists(int doctorId);
        //получение услуг по id доктора
        ICollection<Servicedoctor> GetServices(int doctorId);
        //получение докторов по id услуги
        ICollection<Servicedoctor> GetDoctors(int serviceId);
    }
}
