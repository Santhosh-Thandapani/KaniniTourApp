using System.ComponentModel.DataAnnotations;

namespace TourPackageAPI.Models
{
    public class Package
    {
        [Key]
        public int Id { get; set; }
        public string? PackageName { get; set; }
        public int DaysCount { get; set; }
        public int NightsCount { get; set; }
        public int MaxLimit { get; set; }
        public float Price { get; set; }
        public string? Picture { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string?  HotelStayStatus { get; set; }
        public string? Editable { get; set; }
    }
}
