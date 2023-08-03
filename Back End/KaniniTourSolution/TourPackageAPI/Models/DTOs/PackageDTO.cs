namespace TourPackageAPI.Models.DTOs
{
    public class PackageDTO:Package
    {
        public ICollection<ItineraryDTO>? Itineraries{ get; set; }
    }
}
