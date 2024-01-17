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
using AutoMapper;
using HotelReservationSystemData.ViewModels;

namespace HotelReservationSystem.Controllers
{
    [Route("api/{categoryId}/accommodations")]
    [ApiController]
    public class AccommodationsController : ControllerBase
    {
        private readonly IAccommodationRepository repository;
        private readonly IMapper mapper;

        public AccommodationsController(IAccommodationRepository repository , 
            IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        // GET: api/Accommodations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accommodation>>> GetAccommodations(Guid categoryId)
        {
           

          if (!repository.IsEntityExist())
              return NotFound();

            return Ok(await repository.GetAll(categoryId));
        }

        // GET: api/Accommodations/5
        [HttpGet("{id}" , Name ="Get")]
        public async Task<ActionResult<Accommodation>> GetAccommodation(Guid id, Guid categoryId)
        {
          if (!repository.IsEntityExist())
              return NotFound();
            var accommodation = await repository.GetById(id ,categoryId);

            if (accommodation == null)
                return NotFound();

            return Ok(accommodation);
        }

        // PUT: api/Accommodations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccommodation(Guid accomodationId, AccommodationForUpdate accommodation , Guid catygoryId)
        {
            if (repository.IsEntityExist() ||! await repository.IsExists(accomodationId))
                return NotFound();
            await repository.Update(accommodation, accomodationId, catygoryId);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Accommodation>> PostAccommodation(AccommodationForCreation accommodation , Guid categoryId)
        {
          if (!repository.IsEntityExist())
              return NotFound();
            await repository.Insert(accommodation, categoryId);

            //return CreatedAtAction("GetAccommodation", accommodation);
            return Ok();
        }

        // DELETE: api/Accommodations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccommodation(Guid id , Guid categoryId)
        {
            if (!repository.IsEntityExist())
                return NotFound();
            var accommodation = await repository.GetById(id, categoryId);
            if (accommodation == null)
                return NotFound();
            await repository.Delete(id , categoryId);  

            return NoContent();
        }

    }
}
