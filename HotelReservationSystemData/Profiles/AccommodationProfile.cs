using AutoMapper;
using HotelReservationSystemData.Models;
using HotelReservationSystemData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemData.Profiles
{
    public class AccommodationProfile : Profile
    {
        public AccommodationProfile()
        {
            CreateMap<AccommodationForCreation, Accommodation>();
            CreateMap<AccommodationForUpdate, Accommodation>();
        }
    }
}
