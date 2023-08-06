using System.ComponentModel.DataAnnotations;

namespace BookingAPI.Models
{
    public class HotelBook
    {
        [Key]
        public int StayId { get; set; }
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public DateTime BookingAt { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
