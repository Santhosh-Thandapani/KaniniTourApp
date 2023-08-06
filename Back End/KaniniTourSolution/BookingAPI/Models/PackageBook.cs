using System.ComponentModel.DataAnnotations;

namespace BookingAPI.Models
{
    public class PackageBook
    {
        [Key]
        public int BookingId { get; set; }
        public int PackgeId { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public DateTime BookingAt { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
