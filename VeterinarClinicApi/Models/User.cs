using System;
using System.Collections.Generic;

namespace VeterinarClinicApi.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();
}
