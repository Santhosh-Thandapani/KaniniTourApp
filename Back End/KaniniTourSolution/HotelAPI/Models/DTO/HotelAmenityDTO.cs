namespace HotelAPI.Models.DTO
{
    public class HotelAmenityDTO
    {
        public int HotelId { get; set; }    
        public ICollection<string>? Amenities { get; set; }
    }
}
