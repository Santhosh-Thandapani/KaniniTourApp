using Microsoft.EntityFrameworkCore;

namespace FeedBackAPI.Models.Context
{
    public class FeedbackContext:DbContext
    {
        public FeedbackContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<HotelFeedback> HotelFeedbacks { get; set; }
        public DbSet<PackageFeedback> PackageFeedbacks { get; set; }
    }
}
