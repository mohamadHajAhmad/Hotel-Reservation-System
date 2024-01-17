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
    public class ReservationRepository : IReservationRepository
    {
        private readonly HotelDbContext _context;
        private readonly IMapper mapper;
        private DbSet<Guest> Guests;
        private DbSet<Reservation> Reservations;
        public ReservationRepository(HotelDbContext context,
            IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
            Guests = _context.Set<Guest>();
            Reservations = _context.Set<Reservation>();
        }
        public async Task<List<Reservation>> GetAll(Guid guestId)
        {

            Guest guest = await Guests.FindAsync(guestId);
            if (guest != null)
                return guest.Reservations.ToList();
            return null!;
        }

        public async Task<Reservation> GetById(Guid reservationId, Guid guestId)
        {
            Guest guest = await Guests.FindAsync(guestId);
            if (guest != null)
                return guest.Reservations.Find(a => a.Id == guestId);
            return null!;
        }

        public async Task Insert(ReservationForCreation reservationForCreation, Guid guestId)
        {
            var guest = await Guests.FindAsync(guestId);
            
            if (guest != null)
            {
                Reservation reservation = mapper.Map<Reservation>(reservationForCreation);
                guest.Reservations.Add(reservation);
                await Save();

            }
        }


        public async Task Update(ReservationForUpdate reservationForUpdate, Guid reservationId, Guid guestId)
        {
            Reservation reservation = await GetById(reservationId, guestId);
            Reservations.Attach(reservation);
            mapper.Map(reservationForUpdate, reservation);
            Reservations.Entry(reservation).State = EntityState.Modified;
            await Save();
        }

        public async Task Delete(Guid reservationId, Guid guestId)
        {
            Guest guest = await Guests.FindAsync(guestId);
            if (guest != null)
            {
                Reservation reservation = guest.Reservations.Find(r => r.Id == reservationId);
                if (reservation != null)
                {
                    Reservations.Remove(reservation);
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
            if (Reservations == null)
            {
                return false;
            }

            return true;

        }

        public bool IsExists(Guid reservationId)
        {
            return Reservations.Any(r => r.Id == reservationId);
        }



    }
}
