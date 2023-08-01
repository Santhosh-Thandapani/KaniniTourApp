namespace HotelAPI.Models.DTO
{
    public class RoomDTO:Room
    {
        public ICollection<RoomAmenity>? RoomAmenity { get; set; }
    }
}
