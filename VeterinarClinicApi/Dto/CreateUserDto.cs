﻿namespace VeterinarClinicApi.Dto
{
    public class CreateUserDto
    {
        public string Surname { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
