using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HotelAPI.Models.Context
{
    public class HotelContext: DbContext
    {
        public HotelContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<HotelAmenity> HotelAmenity { get; set; }
        public DbSet<HotelPicture> HotelPicture { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomAmenity> RoomAmenity { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Room>()
        //        .HasOne(r => r.Hotel)
        //        .WithMany(h => h.Rooms)
        //        .HasForeignKey(r => r.HotelId)
        //        .OnDelete(DeleteBehavior.Restrict); 

        //    modelBuilder.Entity<RoomAmenity>()
        //        .HasOne(ra => ra.Room)
        //        .WithMany(r => r.RoomAmenities)
        //        .HasForeignKey(ra => ra.RoomId)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    // Additional configurations and other entity setups
        //}
    }
}
