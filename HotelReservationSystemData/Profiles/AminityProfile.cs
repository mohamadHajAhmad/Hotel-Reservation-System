using AutoMapper;
using HotelReservationSystemData.Models;
using HotelReservationSystemData.ViewModels;

namespace HotelReservationSystemData.Profiles
{
    public class AminityProfile : Profile
    {
        public AminityProfile()
        {
            CreateMap<AminityForCreation, Aminity>();
            CreateMap<AminityForUpdate, Aminity>();
        }
    }
}
