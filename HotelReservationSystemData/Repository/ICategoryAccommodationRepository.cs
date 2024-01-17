using HotelReservationSystemData.Models;
using HotelReservationSystemData.ViewModels;

namespace HotelReservationSystemData.Repository
{
    public interface ICategoryAccommodationRepository
    {
        Task<List<CategoryAccommodation>> GetAll();

        Task<CategoryAccommodation> GetById(Guid id);
        Task Insert(CategoryAccommodationForCreation categoryAccommodation);
        Task Delete(Guid id);
        bool IsEntityExist();
        Task Update(Guid id , CategoryAccommodationForUpdate categoryAccommodation);
        Task<bool> IsExists(Guid id);
        Task Save();
    }


}
