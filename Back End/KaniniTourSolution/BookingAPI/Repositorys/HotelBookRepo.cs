using BookingAPI.Interfaces;
using BookingAPI.Models;
using BookingAPI.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookingAPI.Repositorys
{
    public class HotelBookRepo : IRepo<HotelBook, int>
    {
        private readonly BookingContext _context;

        public HotelBookRepo(BookingContext context)
        {
            _context=context;
        }
        public async Task<HotelBook> Add(HotelBook item)
        {
            _context.HotelBooks.Add(item);
            await _context.SaveChangesAsync();
            return item;

        }

        public async Task<HotelBook> Delete(HotelBook item)
        { 
            _context.HotelBooks.Remove(item);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<HotelBook> Get(int key)
        {
            var result = await _context.HotelBooks.FirstOrDefaultAsync(s=>s.StayId==key);
            if (result != null)
                return result;
            return null;
        }

        public async Task<ICollection<HotelBook>> GetAll()
        {
            var result = await _context.HotelBooks.ToListAsync();
            if (result != null)
                return result;
            return null;
        }

        public Task<HotelBook> Update(HotelBook item)
        {
            throw new NotImplementedException();
        }
    }
}
