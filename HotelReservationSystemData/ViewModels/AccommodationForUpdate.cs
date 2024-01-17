using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemData.ViewModels
{
    public class AccommodationForUpdate
    {
        public string RoomCode { get; set; } = null!;

        public int Floors { get; set; }

        public string? Views { get; set; }

        public int PriceOfNight { get; set; }
    }
}
