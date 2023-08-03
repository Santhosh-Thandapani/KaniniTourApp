namespace FeedBackAPI.Models
{
    public class HotelFeedback
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public DateTime? CreatedAt { get; set;}
        public int Cleanliness { get; set; }
        public int ServiceSupport { get; set; }
        public int Food { get; set; }
        public int Amenities { get; set; }
        public int ValueForMoney { get; set; }
        public string? Review { get; set; }
    }
}
