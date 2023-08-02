using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models
{
    public class HotelAmenity
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel? Hotel { get; set; }
        public string? Amenity { get; set; }
    }
}
