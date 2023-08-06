using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Models.Context
{
    public class BookingContext:DbContext
    {
        public BookingContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<HotelBook> HotelBooks { get; set; }
        public DbSet<HotelGuest> HotelGuests { get; set; }
        public DbSet<PackageBook> PackageBooks { get;set; }
        public DbSet<PackageGuest> PackageGuests { get; set; }

    }
}
