namespace BookingAPI.Models.DTOs
{
    public class PackageBookDTO:PackageBook
    {
        public ICollection<PackageGuest>? Guests { get; set; }
    }
}
