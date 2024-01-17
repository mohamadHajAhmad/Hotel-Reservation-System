using AutoMapper;
using HotelReservationSystemData.Models;
using HotelReservationSystemData.ViewModels;

namespace HotelReservationSystemData.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAccommodationForCreation, CategoryAccommodation>();
            CreateMap<CategoryAccommodationForUpdate, CategoryAccommodation>();
        }
    }
}
