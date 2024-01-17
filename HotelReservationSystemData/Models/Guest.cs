using System;
using System.Collections.Generic;

namespace HotelReservationSystemData.Models;

public partial class Guest
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public int Phone { get; set; }

    public Guid ReservationId { get; set; }

    public DateTime DateOfBirth { get; set; }

    public virtual List<Reservation> Reservations { get; set; }  = new List<Reservation>();
}
