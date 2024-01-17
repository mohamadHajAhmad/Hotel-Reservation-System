using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelReservationSystemData.AppDbContext;
using HotelReservationSystemData.Models;
using HotelReservationSystemData.ViewModels;
using NuGet.Protocol.Core.Types;
using HotelReservationSystemData.Repository;

namespace HotelReservationSystem.Controllers
{
    [Route("api/Accommodation/{accommodationId}/[controller]")]
    [ApiController]
    public class AminitiesController : ControllerBase
    {
        private readonly HotelDbContext _context;
        private readonly IAminityRepository repository;

        public AminitiesController(HotelDbContext context , IAminityRepository repository)
        {
            _context = context;
            this.repository = repository;
        }

        // GET: api/Aminities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aminity>>> GetAminity(Guid accommodationId)
        {


            if (!repository.IsEntityExist())
            {
                return NotFound();
            }

            return Ok(await repository.GetAll(accommodationId));
        }

        // GET: api/Accommodations/5
        [HttpGet("{id}", Name = "GetReservation")]
        public async Task<ActionResult<Aminity>> GetAminity(Guid aminityId, Guid accommodationId)
        {
            if (!repository.IsEntityExist())
            {
                return NotFound();
            }
            var accommodation = await repository.GetById(aminityId, accommodationId);

            if (accommodation == null)
            {
                return NotFound();
            }

            return Ok(accommodation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAminity(Guid aminityId, AminityForUpdate aminity , Guid accommodationId)
        {
            if (repository.IsEntityExist() || !await repository.IsExists(aminityId))
                return NotFound();
            await repository.Update(aminityId, accommodationId, aminity);
            return NoContent();
        }

        // POST: api/Accommodations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Accommodation>> PostAminity(AminityForCreation aminity, Guid accommodationId)
        {
            if (!repository.IsEntityExist())
                return NotFound();
            await repository.Insert(accommodationId, aminity);
            // return CreatedAtAction("GetReservation", aminity);
            return Ok();
        }

        // DELETE: api/Accommodations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAminity(Guid aminityId, Guid accommodationId)
        {
            if (!repository.IsEntityExist())
                return NotFound();
            var accommodation = await repository.GetById(aminityId, accommodationId);
            if (accommodation == null)
                return NotFound();
            await repository.Delete(aminityId, accommodationId);
            return NoContent();
        }

    }
}
