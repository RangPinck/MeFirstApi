namespace VeterinarClinicApi.Dto
{
    public class AnimalDto
    {
        public int AnimalId { get; set; }

        public string Name { get; set; } = null!;

        public int Age { get; set; }

        public string Breed { get; set; } = null!;

        public int Weight { get; set; }

        public string? Description { get; set; }

        public int? Owner { get; set; }

        public string? Image { get; set; }
    }
}
