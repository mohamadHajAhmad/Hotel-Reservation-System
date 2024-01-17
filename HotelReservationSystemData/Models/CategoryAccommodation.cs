using System;
using System.Collections.Generic;

namespace HotelReservationSystemData.Models;

public partial class CategoryAccommodation
{
    public Guid Id { get; set; }

    public string Occupancy { get; set; }

    public string Space { get; set; }

    public string Beds { get; set; }

    public bool IsSuite { get; set; }

    public string BathRoom { get; set; }

    public string Decor { get; set; }

    public string UniqueFeatures { get; set; }

    public virtual List<Accommodation> Accommodations { get; set; } = new List<Accommodation>(); 
}
