using HotelAPI.Interfaces;
using HotelAPI.Models;
using HotelAPI.Models.DTO;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace HotelAPI.Services
{
    public class RoomService : IRoomService<RoomDTO, Room, int>
    {
        private readonly IRoomRepo<Room, int> _roomRepo;
        private readonly IAmenityRepo<RoomAmenity> _roomAmenity;

        public RoomService(IRoomRepo<Room, int> roomRepo,
                           IAmenityRepo<RoomAmenity> roomAmenity)
        {
            _roomRepo=roomRepo;
            _roomAmenity=roomAmenity;
        }
        public async Task<RoomDTO> AddRoom(RoomDTO item)
        {
            var totalRooms = await _roomRepo.GetRoomsByHotel(item.HotelId);
            item.RoomId= (totalRooms.Count())+1;
            var addedRoom = await _roomRepo.Add(item);
            if(item.RoomAmenity!=null)
            {
                foreach (var amt in item.RoomAmenity)
                {
                    RoomAmenity newRoom = new RoomAmenity();
                    newRoom.RoomId=item.RoomId;
                    newRoom.HotelId = item.HotelId;
                    newRoom.Amenity = amt.Amenity;
                    await _roomAmenity.Add(newRoom);
                }
                return item;
            }
            return null;
        }

        public async Task<RoomDTO> RemoveRoom(int id)
        {
            RoomAmenity temp = new RoomAmenity();
            temp.RoomId = id;
            var delAmt = await _roomAmenity.Delete(temp);
            var getRoom = await _roomRepo.Get(id);
            if(getRoom != null)
            {
                var delRoom=await _roomRepo.Delete(getRoom);
                return new RoomDTO();
            }
            return null;
        }

        public async Task<Room> UpdateRoom(Room item)
        {
            var result = await _roomRepo.Update(item);
            if(result != null)
                return result;
            return null;
        }
    }
}
