using Microsoft.EntityFrameworkCore;

namespace TourPackageAPI.Models.Context
{
    public class TourContext :DbContext
    {
        public TourContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Package> Packages { get; set; }    
        public DbSet<Itinerary> Itineraries { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Accomdation> Accomdations { get; set; }
    }
}
