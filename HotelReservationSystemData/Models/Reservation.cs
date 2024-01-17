using System;
using System.Collections.Generic;

namespace HotelReservationSystemData.Models;

public partial class Reservation
{
    public Guid Id { get; set; }

    public DateTime CheckInDate { get; set; }

    public DateTime CheckOutDate { get; set; }

    public int TotalPrice { get; set; }
    public Guid AccommodationId { get; set; }

    public Accommodation Accommodation { get; set; } = null!;

    public  Guest Guest { get; set; } = null!;
    public Guid GuestId { get; set; }
}
