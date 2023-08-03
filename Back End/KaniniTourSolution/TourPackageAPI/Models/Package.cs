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
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string?  HotelStayStatus { get; set; }
        public string? Editable { get; set; }
    }
}
