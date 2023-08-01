using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models
{
    public class HotelPicture
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel? Hotel { get; set; }
        public string? Path { get; set; }
    }
}
