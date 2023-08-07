using Microsoft.EntityFrameworkCore;

namespace EndUserAPI.Models.Context
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Passenger> Passengers{ get; set; }
        public DbSet<TourAgent>TourAgents { get; set; }
        public DbSet<UserTwoFactor> UserTwoFactors { get; set;}
    }
}
