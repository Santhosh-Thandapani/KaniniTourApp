using System.ComponentModel.DataAnnotations.Schema;

namespace BookingAPI.Models
{
    public class PackageGuest
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        [ForeignKey("BookingId")]
        public PackageBook? PackageBook { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
    }
}
