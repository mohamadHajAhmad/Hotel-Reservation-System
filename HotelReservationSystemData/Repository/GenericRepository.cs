using HotelReservationSystemData.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemData.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DbSet<T> table;
        private readonly HotelDbContext _context;
        public GenericRepository(HotelDbContext context )
        {
            this._context = context;
            table = _context.Set<T>();
        }

        public bool IsEntityExist()
        {
            if (table == null)
            {
                return false;
            }

            return true;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        //This method will return the specified record from the table
        //based on the ID which it received as an argument
        public async Task<T> GetById(Guid id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await table.FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        //This method will Insert one Guid into the table
        //It will receive the Guid as an argument which needs to be inserted into the database
        public async Task Insert(T obj)
        {
            //It will mark the Entity state as Added State
           await table.AddAsync(obj);
           await Save();
        }

        //This method is going to update the record in the table
        //It will receive the Guid as an argument
        public void Update(T obj)
        {
        }

        //This method is going to remove the record from the table
        //It will receive the primary key value as an argument whose information needs to be removed from the table
        public async Task Delete(Guid id)
        {

 
            T existing = await table.FindAsync(id);
            if (existing != null)             //This will mark the Entity State as Deleted
                 table.Remove(existing);
            await Save();
        }

        //This method will make the changes permanent in the database
        //That means once we call Insert, Update, and Delete Methods, 
        //Then we need to call the Save method to make the changes permanent in the database
        public async Task Save()
        {
           await _context.SaveChangesAsync();
        }

        public Task Update(object obj)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsExists(Guid id)
        {
            if (await table.FindAsync(id) == null)
            {
                return false;
            }
            return true;
        }

        public Task Insert(object obj)
        {
            throw new NotImplementedException();
        }
    }
}

