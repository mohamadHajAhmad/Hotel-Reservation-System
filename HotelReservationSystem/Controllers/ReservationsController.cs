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
    [Route("api/Guest/{guestId}/Reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly HotelDbContext _context;
        private readonly IReservationRepository repository;

        public ReservationsController(HotelDbContext context , IReservationRepository repository)
        {
            _context = context;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accommodation>>> GetReservations(Guid guestId)
        {


            if (!repository.IsEntityExist())
            {
                return NotFound();
            }

            return Ok(await repository.GetAll(guestId));
        }

        // GET: api/Accommodations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Accommodation>> GetReservation(Guid id, Guid guestId)
        {
            if (!repository.IsEntityExist())
            {
                return NotFound();
            }
            var accommodation = await repository.GetById(id, guestId);

            if (accommodation == null)
            {
                return NotFound();
            }

            return Ok(accommodation);
        }

        // PUT: api/Accommodations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(Guid id, Accommodation accommodation)
        {
            if (id != accommodation.Id)
            {
                return BadRequest();
            }



            try
            {
                await repository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!repository.IsExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // POST: api/Accommodations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Accommodation>> PostReservation(ReservationForCreation reservation, Guid guestId)
        {
            if (!repository.IsEntityExist())
            {
                return NotFound();
            }
            await repository.Insert(reservation, guestId);

            return Ok();
        }

        // DELETE: api/Accommodations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(Guid id, Guid guestId)
        {
            if (!repository.IsEntityExist())
            {
                return NotFound();
            }
            var accommodation = await repository.GetById(id, guestId);
            if (accommodation == null)
            {
                return NotFound();
            }

            await repository.Delete(id, guestId);

            return NoContent();
        }
    }
}
