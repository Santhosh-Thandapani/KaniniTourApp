using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel? Hotel { get; set; }
        public int RoomId { get; set; }
        public string? RoomName { get; set; }
        public int TotalRooms { get; set; }
        public int Size { get; set; }
        public string? BedType { get; set; }
        public string? Type { get; set; }
        public float Price { get; set; }
    }
}
