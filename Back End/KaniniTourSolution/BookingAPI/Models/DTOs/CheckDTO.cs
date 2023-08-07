namespace BookingAPI.Models.DTOs
{
    public interface CheckDTO
    {
        public int PackageId { get; set; }
        public DateTime CheckInDate { get; set; }
    }
}
