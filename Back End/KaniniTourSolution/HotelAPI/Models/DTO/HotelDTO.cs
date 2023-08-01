namespace HotelAPI.Models.DTO
{
    public class HotelDTO:Hotel
    {
        public ICollection<RoomDTO>? Rooms { get; set; }
        public ICollection<HotelAmenity>? HotelAmenities { get; set; }
    }
}
