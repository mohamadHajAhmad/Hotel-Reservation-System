using AutoMapper;
using HotelReservationSystemData.AppDbContext;
using HotelReservationSystemData.Models;
using HotelReservationSystemData.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemData.Repository
{
    public class AmintyRepository : IAminityRepository
    {
        private readonly HotelDbContext _context;
        private readonly IMapper mapper;
        private DbSet<Aminity> Aminities;
        private DbSet<Accommodation> Accommodations;
        public AmintyRepository(HotelDbContext context , IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
            Aminities = _context.Set<Aminity>();
            Accommodations = _context.Set<Accommodation>();
        }
        public async Task<List<Aminity>> GetAll(Guid accommodationId)
        {
            
            var AccommodationResult = await Accommodations.FindAsync(accommodationId);
            if (AccommodationResult != null) 
                 return AccommodationResult.Aminities.ToList();
            return null!;
        }

        public async Task<Aminity> GetById(Guid aminityId, Guid accommodationId)
        {
            var AccommodationsResult = await Accommodations.FindAsync(accommodationId);
            if (AccommodationsResult != null)
                 return AccommodationsResult.Aminities.Find(a => a.Id == aminityId)!;
            return null!;
        }

        public async Task Insert(Guid accommodationId, AminityForCreation aminityForCreation)
        {
            var accomodation = await Accommodations.FindAsync(accommodationId);
            if (accomodation != null)
            {
                Aminity aminity = mapper.Map<Aminity>(aminityForCreation);
                accomodation.Aminities.Add(aminity);
                await Save();

            }
        }

        public bool IsEntityExist()
        {
            if (Aminities == null)
            {
                return false;
            }

            return true;

        }

        public Task<bool> IsExists(Guid aminityId)
        {
            return Aminities.AnyAsync(e =>e.Id== aminityId);
        }



        public async Task Update(Guid aminityId, Guid accomodationId, AminityForUpdate aminityForUpdate)
        {
            var aminity = await GetById(aminityId, accomodationId);
            Aminities.Attach(aminity);
            mapper.Map(aminityForUpdate, aminity);
            Aminities.Entry(aminity).State = EntityState.Modified;
            await Save();
        }

        public async Task Delete(Guid aminityId, Guid accommodationId)
        {
            var AccommodationResult = await Accommodations.FindAsync(accommodationId);
            if (AccommodationResult != null)
            {
                var aminity = AccommodationResult.Aminities.Find(a => a.Id == aminityId);
                if (aminity != null)
                {
                    Aminities.Remove(aminity);
                    _context.SaveChanges();
                }
            }
        }

        public async Task Save()
        {
          await  _context.SaveChangesAsync();
        }
    }
}
