using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemData.ViewModels
{
    public class CategoryAccommodationForUpdate
    {
        public string Occupancy { get; set; }

        public string Space { get; set; }

        public string Beds { get; set; }

        public bool IsSuite { get; set; }

        public string BathRoom { get; set; }

        public string Decor { get; set; }

        public string UniqueFeatures { get; set; }
    }
}
