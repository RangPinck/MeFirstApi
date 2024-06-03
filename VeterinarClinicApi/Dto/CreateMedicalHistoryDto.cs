namespace VeterinarClinicApi.Dto
{
    public class CreateMedicalHistoryDto
    {
        public int Animal { get; set; }

        public DateTime Visitingtime { get; set; }

        public int Doctor { get; set; }

        public int Service { get; set; }
    }
}
