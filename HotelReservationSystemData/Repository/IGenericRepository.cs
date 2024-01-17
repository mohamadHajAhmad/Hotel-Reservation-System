using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemData.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task Insert(object obj);
        Task Delete(Guid id);
        bool IsEntityExist();
        Task Update(object obj);
        Task<bool> IsExists(Guid id);
        Task Save();
    }
}
