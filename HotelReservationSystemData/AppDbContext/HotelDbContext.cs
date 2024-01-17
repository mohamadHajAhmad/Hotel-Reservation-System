using System;
using System.Collections.Generic;
using HotelReservationSystemData.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystemData.AppDbContext;

public partial class HotelDbContext : DbContext
{
    public HotelDbContext()
    {
    }

    public HotelDbContext(DbContextOptions<HotelDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accommodation> Accommodations { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Aminity> Aminities { get; set; }

    public virtual DbSet<CategoryAccommodation> CategoryAccommodations { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=Mohamad-Hilal;Initial Catalog='Hotel reservation system';Integrated Security=True;Trust Server Certificate=True");

}
