using System;
using System.Collections.Generic;

namespace VeterinarClinicApi.Models;

public partial class Medicalhistory
{
    public int KardId { get; set; }

    public int Animal { get; set; }

    public DateTime Visitingtime { get; set; }

    public int Doctor { get; set; }

    public int Service { get; set; }

    public virtual Animal AnimalNavigation { get; set; } = null!;

    public virtual Doctor DoctorNavigation { get; set; } = null!;

    public virtual Service ServiceNavigation { get; set; } = null!;
}
