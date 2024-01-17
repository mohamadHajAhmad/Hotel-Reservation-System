using HotelReservationSystemData.Models;
using HotelReservationSystemData.ViewModels;

namespace HotelReservationSystemData.Repository
{

    public interface IGuestRepository
    {
        Task<List<Guest>> GetAll();
        
        Task<Guest> GetById(Guid id);
        Task Insert(GuestForCreation guestForCreation);
        Task Delete(Guid id);
        bool IsEntityExist();
        Task Update(Guid id, GuestForUpdate guestForUpdate);
        Task<bool> IsExists(Guid id);
        Task Save();
    }

}
