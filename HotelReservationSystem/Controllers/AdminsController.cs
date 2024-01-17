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
using HotelReservationSystemData.Repository;
using HotelReservationSystemData.ViewModels;

namespace HotelReservationSystem.Controllers
{
    [Route("api/Admins")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminRepository repository;

        public AdminsController(IAdminRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        {
          if (!repository.IsEntityExist())
          {
              return NotFound();
          }
            return Ok(await repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdmin(Guid id)
        {
          if (!repository.IsEntityExist())
          {
              return NotFound();
          }
            var admin = await repository.GetById(id);

            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin(Guid id, AdminForUpdate admin)
        {
            if (!repository.IsEntityExist() ||!await repository.IsExists(id))
            {
                return NotFound();
            }
            await repository.Update(id , admin);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Admin>> PostAdmin(AdminForCreation admin)
        {
          if (!repository.IsEntityExist())
          {
              return Problem("Entity set 'HotelDbContext.Admins'  is null.");
          }
            await repository.Insert(admin);
            

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(Guid id)
        {
            if (!repository.IsEntityExist() || !await repository.IsExists(id))
                return NotFound();

           await repository.Delete(id);
           
            return NoContent();
        }

    }
}
