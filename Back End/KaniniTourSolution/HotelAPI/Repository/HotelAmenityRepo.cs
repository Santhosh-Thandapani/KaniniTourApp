using HotelAPI.Interfaces;
using HotelAPI.Models;
using HotelAPI.Models.Context;
using HotelAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Repository
{
    public class HotelAmenityRepo : IAmenityRepo<HotelAmenity>
    {
        private readonly HotelContext _context;

        public HotelAmenityRepo(HotelContext context)
        {
            _context=context;
        }

        public async Task<HotelAmenity> Add(HotelAmenity item)
        {
            try
            {
                if (item != null)
                {
                    _context.HotelAmenity.Add(item);
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

        public async Task<HotelAmenity> Delete(HotelAmenity item)
        {
            try
            {
                if (item != null)
                {
                    var getItem =await _context.HotelAmenity.SingleOrDefaultAsync(
                                           s=>s.HotelId== item.HotelId &&  
                                              s.Amenity==item.Amenity);
                    _context.HotelAmenity.Remove(getItem);
                    await _context.SaveChangesAsync();
                    return getItem;
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
                var amenitiesToRemove = _context.HotelAmenity.Where(s => s.HotelId == id);

                if (amenitiesToRemove.Any())
                {
                     _context.HotelAmenity.RemoveRange(amenitiesToRemove);
                    await _context.SaveChangesAsync();
                }
                if (amenitiesToRemove != null)
                    return true;
                return false;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<ICollection<HotelAmenity>> GetAll(int id)
        {
            var amts = await _context.HotelAmenity.Where(s=>s.HotelId==id).ToListAsync();
            if(amts!=null)
                return amts;
            return null;
        }
    }
}
