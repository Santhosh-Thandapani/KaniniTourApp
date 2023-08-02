using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models
{
    public class RoomAmenity
    {
        [Key]
        public int Id { get; set; }

        public int HotelId { get; set; }
        [ForeignKey("HotelId")]

        public Hotel? Hotel { get; set; }

        public int RoomId { get; set; }

        //public Room? Room { get; set; }  
        public string? Amenity { get; set; }
    }
}
