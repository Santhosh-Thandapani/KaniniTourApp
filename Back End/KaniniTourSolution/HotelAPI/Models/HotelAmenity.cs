using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models
{
    public class HotelAmenity
    {
        public int Id { get; set; }

        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        public string? Amenity { get; set; }
    }
}
