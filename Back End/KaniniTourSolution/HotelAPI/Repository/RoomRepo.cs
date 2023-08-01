using HotelAPI.Interfaces;
using HotelAPI.Models;
using HotelAPI.Models.Context;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace HotelAPI.Repository
{
    public class RoomRepo :IRoomRepo<Room,int>
    {
        private readonly HotelContext _context;

        public RoomRepo(HotelContext context)
        {
            _context=context;
        }

        public async Task<Room> Add(Room item)
        {
            try
            {
                _context.Room.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<Room> Delete(Room item)
        {
            try
            {
                _context.Room.Remove(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<Room> Get(int key)
        {
            try
            {
                var item = await _context.Room.FirstOrDefaultAsync(s => s.Id == key);
                if (item == null)
                    return null;
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<ICollection<Room>> GetAll()
        {
            try
            {
                var hotels = await _context.Room.ToListAsync();
                if (hotels != null)
                    return hotels;
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        public async Task<ICollection<Room>> GetRoomsByHotel(int id)
        {
            try
            {
                var rooms = await _context.Room.Where(s => s.HotelId == id).ToListAsync();
                if (rooms != null)        
                    return rooms;
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<Room> Update(Room item)
        {
            try
            {
                var oldRoom = await _context.Room.FirstOrDefaultAsync(s => s.RoomId == item.Id);
                if (oldRoom != null)
                {
                    oldRoom.RoomName = item.RoomName;
                    oldRoom.TotalRooms = item.TotalRooms;
                    oldRoom.Size = item.Size;
                    oldRoom.BedType = item.BedType;
                    oldRoom.Type = item.Type;
                    oldRoom.Price = item.Price;
                    await _context.SaveChangesAsync();
                    return item;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
