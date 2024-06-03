namespace VeterinarClinicApi.Dto
{
    public class AnimalMedicatHistoryDto
    {
        public int KardId { get; set; }

        public DateTime Visitingtime { get; set; }

        public string Doctor { get; set; }

        public string Service { get; set; }
    }
}
