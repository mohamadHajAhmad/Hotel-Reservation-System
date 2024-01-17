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
    public class AccommdationRepository : IAccommodationRepository
    {
        private readonly HotelDbContext _context;
        private readonly IMapper mapper;
        private DbSet<CategoryAccommodation> Categories;
        private DbSet<Accommodation> Accommodations;
        public AccommdationRepository(HotelDbContext context , 
            IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
            Categories = _context.Set<CategoryAccommodation>();
            Accommodations = _context.Set<Accommodation>();
        }
        public async Task<List<Accommodation>> GetAll(Guid categoryId)
        {

            var category = await Categories.FindAsync(categoryId);
            if (category != null)
                return category.Accommodations.ToList();
            return null!;
        }

        public async Task<Accommodation> GetById(Guid accomodationId, Guid categoryId)
        {
            var category = await Categories.FindAsync(categoryId);
            if (category != null)
                return category.Accommodations.Find(a => a.Id == accomodationId)!;
            return null!;
        }

        public async Task Insert(AccommodationForCreation accommodationForCreation , Guid categoryId)
        {
            var category = await Categories.FindAsync(categoryId);
            if (category != null)
            {
                Accommodation accommodation = mapper.Map<Accommodation>(accommodationForCreation);
                category.Accommodations.Add(accommodation);
                await Save();

            }
        }


        public async Task Update(AccommodationForUpdate accommodationForUpdate ,Guid accomodationId, Guid categoryId)
        {
            var accommodation = await GetById(accomodationId, categoryId);
            Accommodations.Attach(accommodation);
            mapper.Map(accommodationForUpdate, accommodation);
            Accommodations.Entry(accommodation).State = EntityState.Modified;
            await Save();
        }

        public async Task Delete(Guid accommodationId, Guid categoryId)
        {
            var category = await Categories.FindAsync(categoryId);
            if (category != null)
            {
                var Accommodation = category.Accommodations.Find(a => a.Id == accommodationId);
                if (Accommodation != null)
                {
                    Accommodations.Remove(Accommodation);
                    await Save();
                }
            }
        }


        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public bool IsEntityExist()
        {
            if (Accommodations == null)
            {
                return false;
            }

            return true;

        }

        public async Task<bool> IsExists(Guid accomodationId)
        {
                 return await Accommodations.AnyAsync(e => e.Id == accomodationId);
        }



    }
}
