using System;
using System.Collections.Generic;

namespace VeterinarClinicApi.Models;

public partial class Servicedoctor
{
    public int ServiceId { get; set; }

    public int DoctorId { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
