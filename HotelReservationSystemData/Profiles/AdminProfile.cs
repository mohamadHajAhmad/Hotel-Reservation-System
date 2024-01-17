using AutoMapper;
using HotelReservationSystemData.Models;
using HotelReservationSystemData.ViewModels;

namespace HotelReservationSystemData.Profiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<AdminForCreation, Admin>();
            CreateMap<AdminForUpdate, Admin>();
        }
    }
}
