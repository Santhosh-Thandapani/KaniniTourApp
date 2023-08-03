using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourPackageAPI.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        public int PackageId { get; set; }
        [ForeignKey("PackageId")]
        public Package? Package { get; set; }
        public int ItineraryId { get; set; }  
        public string? ActivityName { get; set; }
        public string? Picture { get; set; }
        public string? Spot { get; set; }
        public int CityId { get; set; }
    }
}
