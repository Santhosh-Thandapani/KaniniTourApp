using HotelAPI.Interfaces;
using HotelAPI.Models;
using HotelAPI.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Repository
{
    public class HotelRepo : IRepo<Hotel, int>
    {
        private readonly HotelContext _context;
        public HotelRepo(HotelContext context)
        {
            _context=context;
        }
        public async Task<Hotel> Add(Hotel item)
        {
            try
            {
                _context.Hotel.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<Hotel> Delete(Hotel item)
        {
            try
            { 
                _context.Hotel.Remove(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<Hotel> Update(Hotel item)
        {
            try
            {
                var oldHotel = await Get(item.Id);
                if (item != null && oldHotel != null)
                {
                    oldHotel.Name = item.Name;
                    oldHotel.Street = item.Street;
                    oldHotel.Landmark = item.Landmark;
                    oldHotel.City = item.City;
                    oldHotel.HouseNo = item.HouseNo;
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

        public async Task<Hotel> Get(int key)
        {
            try
            {
                var item = await _context.Hotel.FirstOrDefaultAsync(s => s.Id == key);
                if (item == null)
                    return null;
                return item;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<ICollection<Hotel>> GetAll()
        {
            try
            {
                var hotels = await _context.Hotel.ToListAsync();
                if (hotels != null)
                    return hotels;
                return null;
            }
            catch( Exception ex)
            {
                throw new Exception(ex.ToString());
            } 
        }

       
    }
}
