using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemData.ViewModels
{
    public class GuestForUpdate
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int Phone { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
