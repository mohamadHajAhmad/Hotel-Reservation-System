using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelReservationSystemData.AppDbContext;
using HotelReservationSystemData.Models;
using HotelReservationSystemData.Repository;
using HotelReservationSystemData.ViewModels;

namespace HotelReservationSystem.Controllers
{
    [Route("api/CategoryAccommodations")]
    [ApiController]
    public class CategoryAccommodationsController : ControllerBase
    {
        private readonly ICategoryAccommodationRepository repository;

        public CategoryAccommodationsController(ICategoryAccommodationRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/CategoryAccommodations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryAccommodation>>> GetCategoryAccommodations()
        {
          if (!repository.IsEntityExist())
          {
              return NotFound();
          }
            return Ok(await repository.GetAll());
        }

        // GET: api/CategoryAccommodations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryAccommodation>> GetCategoryAccommodation(Guid id)
        {
          if (!repository.IsEntityExist())
          {
              return NotFound();
          }
            var categoryAccommodation = await repository.GetById(id);

            if (categoryAccommodation == null)
            {
                return NotFound();
            }

            return Ok(categoryAccommodation);
        }

        // PUT: api/CategoryAccommodations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryAccommodation(Guid id, CategoryAccommodationForUpdate categoryAccommodation)
        {
            if (!repository.IsEntityExist() || !await repository.IsExists(id))
                return NotFound();
            await repository.Update(id, categoryAccommodation);
            return NoContent();
        }

        // POST: api/CategoryAccommodations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryAccommodationForCreation>> PostCategoryAccommodation(CategoryAccommodationForCreation categoryAccommodation)
        {
          if (!repository.IsEntityExist())
          {
              return NotFound();
          }

           await repository.Insert(categoryAccommodation);

            return Ok();
        }

        // DELETE: api/CategoryAccommodations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAccommodation(Guid id)
        {
            if (!repository.IsEntityExist() || !await repository.IsExists(id))
                return NotFound();

            await repository.Delete(id);
            return NoContent();
        }

    }
}
