using HotelReservationSystemData.Models;
using HotelReservationSystemData.ViewModels;

namespace HotelReservationSystemData.Repository
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetAll(Guid guestId);
        Task<Reservation> GetById(Guid reservationId, Guid guestId);
        Task Insert(ReservationForCreation reservationForCreation, Guid guestId);
        Task Delete(Guid reservationId, Guid guestId);
        bool IsEntityExist();
        Task Update(ReservationForUpdate reservationForUpdate, Guid reservationId, Guid guestId);
        bool IsExists(Guid reservationId);
        Task Save();
    }

}
