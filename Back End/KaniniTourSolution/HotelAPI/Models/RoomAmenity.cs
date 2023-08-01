using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models
{
    public class RoomAmenity
    {
        public int Id { get; set; }

        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }

        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }  
        public string? Amenity { get; set; }
    }
}
