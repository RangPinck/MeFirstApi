using System;
using System.Collections.Generic;

namespace VeterinarClinicApi.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double Price { get; set; }

    public virtual ICollection<Medicalhistory> Medicalhistories { get; set; } = new List<Medicalhistory>();
}
