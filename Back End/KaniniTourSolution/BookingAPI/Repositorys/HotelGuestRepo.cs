using BookingAPI.Interfaces;
using BookingAPI.Models;
using BookingAPI.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Repositorys
{
    public class HotelGuestRepo : IRepo<HotelGuest, int>
    {
        private readonly BookingContext _context;

        public HotelGuestRepo(BookingContext context)
        {
            _context=context;
        }
        public async Task<HotelGuest> Add(HotelGuest item)
        {
            _context.HotelGuests.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<HotelGuest> Delete(HotelGuest item)
        {
            _context.HotelGuests.Remove(item);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<HotelGuest> Get(int key)
        {
            var result = await _context.HotelGuests.FirstOrDefaultAsync(s => s.StayId == key);
            if (result != null)
                return result;
            return null;
        }

        public async Task<ICollection<HotelGuest>> GetAll()
        {
            var result = await _context.HotelGuests.ToListAsync();
            if (result != null)
                return result;
            return null;
        }

        public async Task<HotelGuest> Update(HotelGuest item)
        {
            throw new NotImplementedException();
        }
    }
}
