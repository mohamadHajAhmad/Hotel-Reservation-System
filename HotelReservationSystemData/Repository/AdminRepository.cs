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
    public class AdminRepository : IAdminRepository
    {
        private DbSet<Admin> Admins;
        private readonly HotelDbContext _context;
        private readonly IMapper mapper;

        public AdminRepository(HotelDbContext context, IMapper mapper)
        {
            this._context = context;
            this.mapper = mapper;
            Admins = _context.Set<Admin>();
        }

        public bool IsEntityExist()
        {
            if (Admins == null)
            {
                return false;
            }

            return true;
        }
        public async Task<List<Admin>> GetAll()
        {
            return await Admins.ToListAsync();
        }


        public async Task<Admin> GetById(Guid id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await Admins.FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task Insert(AdminForCreation adminForCreation)
        {
            Admin admin = mapper.Map<Admin>(adminForCreation);
            await Admins.AddAsync(admin);
            await Save();
        }

        public async Task Update(Guid id , AdminForUpdate adminForUpdate)
        {
            var admin = await GetById(id);
            Admins.Attach(admin);
            mapper.Map(adminForUpdate, admin);
            Admins.Entry(admin).State = EntityState.Modified;
            await Save();
        }
        public async Task Delete(Guid id)
        {
            Admin existing = await Admins.FindAsync(id);
            Admins.Remove(existing);
            await Save();
        }

       public async Task<Admin> ValidateUserCredentials(string username, string password)
        {
           return await Admins.FirstOrDefaultAsync(a =>a.UserName.Equals(username) && a.Password.Equals(password));
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsExists(Guid id)
        {
            return await Admins.AnyAsync(e => e.Id == id);
        }

    }
}
