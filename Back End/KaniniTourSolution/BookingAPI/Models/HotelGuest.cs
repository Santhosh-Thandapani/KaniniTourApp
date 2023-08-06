using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingAPI.Models
{
    public class HotelGuest
    {
        [Key]
        public int Id { get; set; }
        public int StayId { get; set; }
        [ForeignKey("StayId")]
        public HotelBook? HotelBook { get; set; }
        public string? Name  { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
    }
}
