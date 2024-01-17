using HotelReservationSystemData.Models;
using HotelReservationSystemData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemData.Repository
{
    public interface IAminityRepository 
    {
        Task<List<Aminity>> GetAll(Guid accommodationId);
        Task<Aminity> GetById(Guid aminityId  , Guid accommodationId);
        Task Insert(Guid accommodationId, AminityForCreation aminityForCreation);
        Task Delete(Guid aminityId, Guid accommodationId);
        bool IsEntityExist();
        Task Update(Guid aminityId ,Guid accomodationId, AminityForUpdate aminityForUpdate);
        Task<bool> IsExists(Guid aminityId);
        Task Save();
    }
}
