namespace FeedBackAPI.Models
{
    public class PackageFeedback
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int Accommodation { get; set; }
        public int LocalExperience { get; set; }
        public int OverallExperience { get; set; }
        public int Communication { get; set; }
        public int ValueForMoney { get; set; }
        public string? Review { get; set; }
    }
}
