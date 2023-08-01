using HotelAPI.Interfaces;
using HotelAPI.Models;
using HotelAPI.Models.Context;
using HotelAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

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

        public Task<HotelAmenity> Delete(HotelAmenity item)
        {
            throw new NotImplementedException();
        }
    }
}
