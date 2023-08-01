namespace HotelAPI.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int HouseNo { get; set; }
        public string? Street { get; set; }
        public string? Landmark { get; set; }   
        public int CityId { get; set; }
    }
}
