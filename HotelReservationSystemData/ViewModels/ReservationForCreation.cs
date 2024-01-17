using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemData.ViewModels
{
    public class ReservationForCreation
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int TotalPrice { get; set; }
        public Guid AccommodationId { get; set; }
        public Guid GuestId { get; set; }

    }
}
