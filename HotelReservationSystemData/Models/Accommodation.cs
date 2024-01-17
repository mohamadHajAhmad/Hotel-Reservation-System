using System;
using System.Collections.Generic;

namespace HotelReservationSystemData.Models;

public partial class Accommodation
{
    public Guid Id { get; set; }

    public string RoomCode { get; set; } = null!;

    public int Floors { get; set; }

    public string Views { get; set; }

    public int PriceOfNight { get; set; }

    public  List<Aminity> Aminities { get; set; } = new List<Aminity>();

    public CategoryAccommodation CategoryAccommodation { get; set; } = null!;

    public Guid CategoryAccommodationsId { get; set; }
    public  List<Reservation> Reservations { get; set; } = new List<Reservation>();
}
