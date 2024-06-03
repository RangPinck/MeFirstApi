using System;
using System.Collections.Generic;

namespace VeterinarClinicApi.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateOnly Hiredate { get; set; }

    public string Profession { get; set; } = null!;

    public string? Honors { get; set; }

    public virtual ICollection<Medicalhistory> Medicalhistories { get; set; } = new List<Medicalhistory>();
}
