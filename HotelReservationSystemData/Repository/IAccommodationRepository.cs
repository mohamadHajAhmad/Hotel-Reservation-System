using HotelReservationSystemData.Models;
using HotelReservationSystemData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemData.Repository
{
    public interface IAccommodationRepository 
    {
        Task<List<Accommodation>> GetAll(Guid categoryId);
        Task<Accommodation> GetById(Guid accommodationId, Guid categoryId);
        Task Insert(AccommodationForCreation accommodationForCreation , Guid categoryId);
        Task Delete(Guid accommodationId, Guid categoryId);
        bool IsEntityExist();
        Task Update(AccommodationForUpdate accommodationForUpdat, Guid accommodationId,Guid categoryId);
        Task<bool> IsExists(Guid accommodationId);
        Task Save();
    }
}
