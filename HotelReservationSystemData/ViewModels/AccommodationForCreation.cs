using HotelReservationSystemData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemData.ViewModels
{
    public class AccommodationForCreation
    {
        public string RoomCode { get; set; } = null!;

        public int Floor { get; set; }

        public string Views { get; set; }

        public Guid CategoryAccommodationsId { get; set; }
        public int PriceOfNight { get; set; }
    }
}
