using System.ComponentModel.DataAnnotations.Schema;

namespace TourPackageAPI.Models
{
    public class Accomdation
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        [ForeignKey("PackageId")]
        public Package? Package { get; set; }
        public int ItineraryId { get; set; }
        public int HotelId { get; set; }
        public int RoomId { get; set; }

    }
}
