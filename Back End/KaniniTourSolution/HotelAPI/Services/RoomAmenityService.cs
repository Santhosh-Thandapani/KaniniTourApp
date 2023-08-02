using HotelAPI.Interfaces;
using HotelAPI.Models;

namespace HotelAPI.Services
{
    public class RoomAmenityService : IAmenityService<RoomAmenity>
    {
        private readonly IAmenityRepo<RoomAmenity> _roomAmenity;
        public RoomAmenityService(IAmenityRepo<RoomAmenity> roomAmenity)
        {
            _roomAmenity = roomAmenity;
        }

        public async Task<RoomAmenity> AddAmenity(RoomAmenity item)
        {
            var result = await _roomAmenity.Add(item);
            if (result != null)
                return result;
            return null;
        }

        public async Task<RoomAmenity> RemoveAmenity(RoomAmenity item)
        {
            var result = await _roomAmenity.Delete(item);
            if (result != null)
                return result;
            return null;
        }
    }
}
