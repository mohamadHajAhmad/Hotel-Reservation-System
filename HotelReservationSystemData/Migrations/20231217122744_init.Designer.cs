﻿// <auto-generated />
using System;
using HotelReservationSystemData.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelReservationSystemData.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    [Migration("20231217122744_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelReservationSystemData.Models.Accommodation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Floors")
                        .HasColumnType("int")
                        .HasColumnName("floors");

                    b.Property<int?>("PriceOfNight")
                        .HasColumnType("int");

                    b.Property<string>("RoomCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nchar(20)")
                        .IsFixedLength();

                    b.Property<string>("Views")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accommodations");
                });

            modelBuilder.Entity("HotelReservationSystemData.Models.Admin", b =>
                {
                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<Guid>("Id")
                        .HasMaxLength(10)
                        .HasColumnType("uniqueidentifier")
                        .IsFixedLength();

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("HotelReservationSystemData.Models.Aminity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccommodationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AminityDesciption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AminityType")
                        .HasMaxLength(150)
                        .HasColumnType("nchar(150)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.ToTable("Aminities");
                });

            modelBuilder.Entity("HotelReservationSystemData.Models.CategoryAccommodation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid>("AccommodationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BathRoom")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("Beds")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("Decor")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<bool>("IsSuite")
                        .HasMaxLength(10)
                        .HasColumnType("bit")
                        .IsFixedLength();

                    b.Property<string>("Occupancy")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("Space")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<string>("UniqueFeatures")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.ToTable("CategoryAccommodations");
                });

            modelBuilder.Entity("HotelReservationSystemData.Models.Guest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nchar(200)")
                        .IsFixedLength();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nchar(100)")
                        .IsFixedLength();

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nchar(100)")
                        .IsFixedLength();

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<Guid>("ReservationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("HotelReservationSystemData.Models.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid>("AccommodationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CheckInData")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("CheckOutData")
                        .HasColumnType("datetime");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("HotelReservationSystemData.Models.Aminity", b =>
                {
                    b.HasOne("HotelReservationSystemData.Models.Accommodation", "Accommodation")
                        .WithMany("Aminities")
                        .HasForeignKey("AccommodationId")
                        .IsRequired()
                        .HasConstraintName("FK_Aminities_Accommodations");

                    b.Navigation("Accommodation");
                });

            modelBuilder.Entity("HotelReservationSystemData.Models.CategoryAccommodation", b =>
                {
                    b.HasOne("HotelReservationSystemData.Models.Accommodation", "Accommodation")
                        .WithMany("CategoryAccommodations")
                        .HasForeignKey("AccommodationId")
                        .IsRequired()
                        .HasConstraintName("FK_CategoryAccommodations_Accommodations");

                    b.Navigation("Accommodation");
                });

            modelBuilder.Entity("HotelReservationSystemData.Models.Guest", b =>
                {
                    b.HasOne("HotelReservationSystemData.Models.Reservation", "Reservation")
                        .WithMany("Guests")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Guests_Reservations");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("HotelReservationSystemData.Models.Reservation", b =>
                {
                    b.HasOne("HotelReservationSystemData.Models.Accommodation", "Accommodation")
                        .WithMany("Reservations")
                        .HasForeignKey("AccommodationId")
                        .IsRequired()
                        .HasConstraintName("FK_Reservations_Accommodations");

                    b.Navigation("Accommodation");
                });

            modelBuilder.Entity("HotelReservationSystemData.Models.Accommodation", b =>
                {
                    b.Navigation("Aminities");

                    b.Navigation("CategoryAccommodations");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("HotelReservationSystemData.Models.Reservation", b =>
                {
                    b.Navigation("Guests");
                });
#pragma warning restore 612, 618
        }
    }
}
