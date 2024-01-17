using AutoMapper;
using HotelReservationSystemData.AppDbContext;
using HotelReservationSystemData.Models;
using HotelReservationSystemData.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemData.Repository
{
    public class GuestRepository  : IGuestRepository
    {
        private DbSet<Guest> Guests;
        private readonly HotelDbContext _context;
        private readonly IMapper mapper;

        public GuestRepository(HotelDbContext context , IMapper mapper)
        {
            this._context = context;
            this.mapper = mapper;
            Guests = _context.Set<Guest>();
        }

        public bool IsEntityExist()
        {
            if (Guests == null)
            {
                return false;
            }

            return true;
        }
        public async Task<List<Guest>> GetAll()
        {
            return await Guests.ToListAsync();
        }
        public async Task<Guest> GetById(Guid id)
        {
            return await Guests.FindAsync(id);
        }


        public async Task Insert(GuestForCreation guestForCreation)
        {
           Guest guest=  mapper.Map<Guest>(guestForCreation);
            await Guests.AddAsync(guest);
            await Save();
        }

        //This method is going to update the record in the table
        //It will receive the Guid as an argument
        public async Task Update(Guid id , GuestForUpdate guestForUpdate)
        {
            var guest = await GetById(id);
            Guests.Attach(guest);
            mapper.Map(guestForUpdate, guest);
            Guests.Entry(guest).State = EntityState.Modified;
            await Save();
        }

        //This method is going to remove the record from the table
        //It will receive the primary key value as an argument whose information needs to be removed from the table
        public async Task Delete(Guid id)
        {
            Guest existing = await Guests.FindAsync(id);
            if (existing != null)             //This will mark the Entity State as Deleted
                Guests.Remove(existing);
            await Save();
        }

        //This method will make the changes permanent in the database
        //That means once we call Insert, Update, and Delete Methods, 
        //Then we need to call the Save method to make the changes permanent in the database
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsExists(Guid id)
        {
            return await Guests.AnyAsync(e => e.Id == id);
        }

    }
}
