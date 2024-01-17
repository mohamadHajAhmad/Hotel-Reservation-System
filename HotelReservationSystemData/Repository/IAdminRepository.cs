using HotelReservationSystemData.Models;
using HotelReservationSystemData.ViewModels;

namespace HotelReservationSystemData.Repository
{
    public interface IAdminRepository
    {
        Task<List<Admin>> GetAll();

        Task<Admin> GetById(Guid id);
        Task Insert(AdminForCreation adminForCreation);
        Task Delete(Guid id);
        bool IsEntityExist();
        Task Update(Guid id, AdminForUpdate adminForUpdate);
        Task<bool> IsExists(Guid id);
        Task<Admin> ValidateUserCredentials(string username, string password);
        Task Save();
    }


}
