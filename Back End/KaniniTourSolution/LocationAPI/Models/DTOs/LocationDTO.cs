namespace LocationAPI.Models.DTOs
{
    public class LocationDTO
    {
        public int cityId { get; set; }
        public string? cityName { get; set; }
        public int StateId { get; set; }
        public string? StateName { get; set; }
        public int CountryId { get; set; }
        public string? CountryName { get; set; }
    }
}
