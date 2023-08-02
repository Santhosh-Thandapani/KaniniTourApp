using HotelAPI.Interfaces;
using HotelAPI.Models;
using HotelAPI.Models.DTO;

namespace HotelAPI.Services
{
    public class HotelService:IHotelService<Hotel,HotelDTO,int>
    {
        private readonly IRepo<Hotel, int> _hotelRepo;
        private readonly IRoomRepo<Room, int> _roomRepo;
        private readonly IAmenityRepo<RoomAmenity> _roomAmenity;
        private readonly IAmenityRepo<HotelAmenity> _hotelAmenity;

        public HotelService(
            IRepo<Hotel, int> hotelRepo,
            IRoomRepo<Room, int> roomRepo,
            IAmenityRepo<RoomAmenity> roomAmenity,
            IAmenityRepo<HotelAmenity> hotelAmenity)
        {
            _hotelRepo=hotelRepo;
            _roomRepo=roomRepo;
            _roomAmenity=roomAmenity;
            _hotelAmenity=hotelAmenity;
        }

        public async Task<HotelDTO> AddHotel(HotelDTO hotel)
        {
            var addedHotel = await _hotelRepo.Add(hotel);
            foreach(var item in hotel.Rooms) 
            {
                var roomList = await _roomRepo.GetRoomsByHotel(addedHotel.Id);
                var roomCount = roomList.Count();
                item.RoomId= 100+(++roomCount);
                item.HotelId = addedHotel.Id;
                var addedRoom = await _roomRepo.Add(item);
                foreach(var a in item.RoomAmenity)
                {
                    RoomAmenity temp = new RoomAmenity();
                    temp.HotelId = addedHotel.Id;
                    temp.RoomId = addedRoom.RoomId;
                    temp.Amenity = a.Amenity;
                    var addedAmenity =await _roomAmenity.Add(temp);
                }
            }
            foreach(var item in hotel.HotelAmenities)
            {
                HotelAmenity amt = new HotelAmenity();
                amt.HotelId= addedHotel.Id;
                amt.Amenity= item.Amenity;
                var addedAmt = await _hotelAmenity.Add(amt);
            }
            if(addedHotel != null)
                return hotel;
            return null;
        }

        public async Task<Hotel> DeleteHotel(int id)
        {
            var delRoomAmt =await _roomAmenity.DeleteByHotel(id);
            var delHotelAmt = await _hotelAmenity.DeleteByHotel(id);
            var delRoom = await _roomRepo.DeleteRooms(id);
            var hotel = await _hotelRepo.Get(id);
            if(hotel != null && delHotelAmt==true && delRoomAmt==true && delRoom == true )
            {
                var delHotel = await _hotelRepo.Delete(hotel);
                if(delHotel !=null)
                    return delHotel;
                return null;
            }
            return null;
        }

        public async Task<ICollection<HotelDTO>> GetAllHotel()
        {
            List<HotelDTO> list = new List<HotelDTO>(); 
            var hotels = await _hotelRepo.GetAll();
            foreach(var hotel in hotels)
            {
                HotelDTO newHotelDTO = new HotelDTO();

                newHotelDTO.Id = hotel.Id;
                newHotelDTO.Name=hotel.Name;
                newHotelDTO.HouseNo=hotel.HouseNo;
                newHotelDTO.Street=hotel.Street;
                newHotelDTO.Landmark=hotel.Landmark;
                newHotelDTO.CityId=hotel.CityId;

                newHotelDTO.HotelAmenities = await _hotelAmenity.GetAll(hotel.Id);

                List<RoomDTO> listRoom = new List<RoomDTO>();
                
                var rooms = await _roomRepo.GetRoomsByHotel(hotel.Id);
                foreach (var room in rooms)
                {
                    RoomDTO newRoomDTO = new RoomDTO();
                    newRoomDTO.Id = room.Id;
                    newRoomDTO.HotelId= room.Id;
                    newRoomDTO.RoomId = room.RoomId;
                    newRoomDTO.TotalRooms= room.TotalRooms;
                    newRoomDTO.Size=room.Size;
                    newRoomDTO.BedType=room.BedType;
                    newRoomDTO.Type=room.Type;
                    newRoomDTO.Price=room.Price;
                    newRoomDTO.RoomAmenity = await _roomAmenity.GetAll(room.RoomId);
                    listRoom.Add(newRoomDTO);
                }
                newHotelDTO.Rooms= listRoom;

                list.Add(newHotelDTO);
            }
            if (list != null)
                return list;
            return null;

        }

        public async Task<HotelDTO> GetHotel(int id)
        {
            var hotelList = await GetAllHotel();
            var getHotel = hotelList.FirstOrDefault(s=>s.Id==id);
            if(getHotel != null)
                return getHotel;
            return null;
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            var updatedHotel = await _hotelRepo.Update(hotel);
            if(updatedHotel != null)
                return updatedHotel;
            return null;
        }
    }
}
