namespace BookingAPI.Models.DTOs
{
    public class CancelDTO
    {
        public int StayId { get; set; }
        public DateTime CancelDate { get; set; }
        public int DateCount { get;set; }
    }
}
