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
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomAmenity> RoomAmenity { get; set; }

       
    }
}
