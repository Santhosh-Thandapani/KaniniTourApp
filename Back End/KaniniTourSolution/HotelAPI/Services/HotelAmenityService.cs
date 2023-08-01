using HotelAPI.Interfaces;
using HotelAPI.Models;

namespace HotelAPI.Services
{
    public class HotelAmenityService : IAmenityService<HotelAmenity>
    {
        private readonly IAmenityRepo<HotelAmenity> _hotelAmenity;
        public HotelAmenityService(IAmenityRepo<HotelAmenity> hotelAmenity)
        {
            _hotelAmenity = hotelAmenity;
        }
        public async Task<HotelAmenity> AddAmenity(HotelAmenity item)
        {
            var result = await _hotelAmenity.Add(item);
            if(result!=null)
                return result;
            return null;
        }

        public async Task<HotelAmenity> RemoveAmenity(HotelAmenity item)
        {
            var result = await _hotelAmenity.Delete(item);
            if (result != null)
                return result;
            return null;
        }
    }
}
