using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelReservationSystemData.AppDbContext;
using HotelReservationSystemData.Models;
using NuGet.Protocol.Core.Types;
using HotelReservationSystemData.ViewModels;
using HotelReservationSystemData.Repository;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private readonly HotelDbContext _context;
        private readonly IGuestRepository repository;

        public GuestsController(HotelDbContext context , IGuestRepository repository)
        {
            _context = context;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guest>>> GetGuests()
        {
            if (!repository.IsEntityExist())
                return NotFound();
            return Ok(await repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Guest>> GetGuest(Guid id)
        {
            if (!repository.IsEntityExist())
                return NotFound();
            var guest = await repository.GetById(id);

            if (guest == null)
                return NotFound();
            return Ok(guest);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuest(Guid id, GuestForUpdate guest)
        {
            if (!repository.IsEntityExist() || !await repository.IsExists(id))
                return NotFound();
            await repository.Update(id, guest);
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<Guest>> PostGuest(GuestForCreation guest)
        {
            if (!repository.IsEntityExist())
                return Problem("Entity set 'HotelDbContext.Guests'  is null.");
            await repository.Insert(guest);
            return Ok();
        }

        // DELETE: api/Guests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuest(Guid id)
        {
            if (!repository.IsEntityExist() || !await repository.IsExists(id))
                return NotFound();

           await repository.Delete(id);
           
            return NoContent();
        }
    }
}
