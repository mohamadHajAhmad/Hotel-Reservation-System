using AutoMapper;
using HotelReservationSystemData.Models;
using HotelReservationSystemData.ViewModels;

namespace HotelReservationSystemData.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<ReservationForCreation, Reservation>();
            CreateMap<ReservationForUpdate, Reservation>();
        }
    }
}
