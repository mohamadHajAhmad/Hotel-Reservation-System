using System;
using System.Collections.Generic;

namespace HotelReservationSystemData.Models;

public partial class Aminity
{
    public Guid Id { get; set; }

    public string AminityDesciption { get; set; } 

    public string AminityName { get; set; }
    public Guid AccommodationId { get; set; }

    public virtual Accommodation Accommodation { get; set; }
}
