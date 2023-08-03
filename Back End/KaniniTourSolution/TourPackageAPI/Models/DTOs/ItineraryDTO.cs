namespace TourPackageAPI.Models.DTOs
{
    public class ItineraryDTO:Itinerary
    {
        public ICollection<Activity>? Activities { get; set; }
        public Accomdation? Stay { get; set; }
    }
}
