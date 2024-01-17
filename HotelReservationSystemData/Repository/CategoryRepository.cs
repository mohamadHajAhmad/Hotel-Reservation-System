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
    public class CategoryRepository : ICategoryAccommodationRepository
    {
        private readonly DbSet<CategoryAccommodation> Categories;
        private readonly HotelDbContext _context;
        private readonly IMapper mapper;

        public CategoryRepository(HotelDbContext context, IMapper mapper)
        {
            this._context = context;
            this.mapper = mapper;
            Categories = _context.Set<CategoryAccommodation>();
        }

        public bool IsEntityExist()
        {
            if (Categories == null)
            {
                return false;
            }

            return true;
        }
        public async Task<List<CategoryAccommodation>> GetAll()
        {
            return await Categories.ToListAsync();
        }


        public async Task<CategoryAccommodation> GetById(Guid id)
        {
            return await Categories.FindAsync(id);
        }

        public async Task Insert(CategoryAccommodationForCreation categoryAccommodationForCreation)
        {
            CategoryAccommodation Category = mapper.Map<CategoryAccommodation>(categoryAccommodationForCreation);
            await Categories.AddAsync(Category);
            await Save();
        }

        public async Task Update(Guid id, CategoryAccommodationForUpdate categoryAccommodationForUpdate)
        {
            var category = await GetById(id);
            Categories.Attach(category);
            mapper.Map(categoryAccommodationForUpdate, category);
            Categories.Entry(category).State = EntityState.Modified;
            await Save();
        }
        public async Task Delete(Guid id)
        {
                CategoryAccommodation category = await Categories.FindAsync(id);
                if (category != null)
                {
                    Categories.Remove(category);
                    await Save();
                }   

        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsExists(Guid id)
        {
            return await Categories.AnyAsync(e => e.Id == id);
        }

    }
}
