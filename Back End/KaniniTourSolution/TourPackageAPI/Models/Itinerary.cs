using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourPackageAPI.Models
{
    public class Itinerary
    {
        [Key]
        public int Id { get; set; }
        public int PackageId { get;set; }
        [ForeignKey("PackageId")]
        public Package? Package { get; set; }    
        public string? Transport { get; set; }
        public float TransportFair { get; set; }
        public string? Food { get; set; }
        public float FoodFair { get; set; }
    }
}
