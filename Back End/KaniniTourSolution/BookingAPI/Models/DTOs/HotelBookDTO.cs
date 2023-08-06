namespace BookingAPI.Models.DTOs
{
    public class HotelBookDTO:HotelBook
    {
        public ICollection<HotelGuest>? Guests { get; set; }    
    }
}
