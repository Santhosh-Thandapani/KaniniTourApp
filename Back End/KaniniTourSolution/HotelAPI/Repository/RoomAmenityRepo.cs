using HotelAPI.Interfaces;
using HotelAPI.Models;
using HotelAPI.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Repository
{
    public class RoomAmenityRepo : IAmenityRepo<RoomAmenity>
    {
        private readonly HotelContext _context;

        public RoomAmenityRepo(HotelContext context)
        {
            _context = context;            
        }
        public async Task<RoomAmenity> Add(RoomAmenity item)
        {
            try
            {
                if (item != null)
                {
                    _context.RoomAmenity.Add(item);
                    await _context.SaveChangesAsync();
                    return item;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        public async Task<RoomAmenity> Delete(RoomAmenity item)
        {
            try
            {
                if (item != null)
                {
                    if ( item.RoomId != null && item.Amenity == null)
                    {
                        var amenitiesToRemove = _context.RoomAmenity.Where(s => s.RoomId == item.RoomId 
                                                                  && s.HotelId == item.HotelId );

                        if (amenitiesToRemove.Any())
                        {
                            _context.RoomAmenity.RemoveRange(amenitiesToRemove);
                            await _context.SaveChangesAsync();
                        }
                    }
                    else
                    {
                        var getItem = await _context.RoomAmenity.SingleOrDefaultAsync(
                                           s => s.HotelId == item.HotelId
                                           && s.RoomId == item.RoomId
                                           && s.Amenity == item.Amenity);

                        _context.RoomAmenity.Remove(getItem);
                        await _context.SaveChangesAsync();
                        return getItem;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> DeleteByHotel(int id)
        {
            try
            {
                var amenitiesToRemove = _context.RoomAmenity.Where(s => s.HotelId == id);

                if (amenitiesToRemove.Any())
                {
                    _context.RoomAmenity.RemoveRange(amenitiesToRemove);
                    await _context.SaveChangesAsync();
                }
                if (amenitiesToRemove != null)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<ICollection<RoomAmenity>> GetAll(int id)
        {
            var amts = await _context.RoomAmenity.Where(s => s.RoomId == id).ToListAsync();
            if (amts != null)
                return amts;
            return null;
        }
    }
}
