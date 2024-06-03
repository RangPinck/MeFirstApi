using VeterinarClinicApi.Models;

namespace VeterinarClinicApi.Interfaces
{
    public interface IMedicalHistoryOfAnimal
    {
        //получение истории болезней питомца
        ICollection<Medicalhistory> GetMedicalHistoryOfAnimal(int animalId);
        //проверка наличия у питомца истории болезней
        bool AnimalExistInMedicalHistory(int animalId);
        //создание записи на приём
        bool CreateAppointment(Medicalhistory mh);
        //Сохранение изменений
        bool Save();
        //получение всей истории болезней
        ICollection<Medicalhistory> GetMedicalHistoryAll();


    }
}
