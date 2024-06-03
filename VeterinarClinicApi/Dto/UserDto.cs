namespace VeterinarClinicApi.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string Surname { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
