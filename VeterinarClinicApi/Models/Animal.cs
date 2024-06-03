using System;
using System.Collections.Generic;

namespace VeterinarClinicApi.Models;

public partial class Animal
{
    public int AnimalId { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public string Breed { get; set; } = null!;

    public int Weight { get; set; }

    public string? Description { get; set; }

    public int? Owner { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<Medicalhistory> Medicalhistories { get; set; } = new List<Medicalhistory>();

    public virtual User? OwnerNavigation { get; set; }
}
