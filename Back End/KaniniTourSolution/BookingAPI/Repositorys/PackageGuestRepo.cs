using BookingAPI.Interfaces;
using BookingAPI.Models;
using BookingAPI.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Repositorys
{
    public class PackageGuestRepo : IRepo<PackageGuest, int>
    {
        private readonly BookingContext _context;

        public PackageGuestRepo(BookingContext context)
        {
            _context = context;
        }
        public async Task<PackageGuest> Add(PackageGuest item)
        {
            _context.PackageGuests.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<PackageGuest> Delete(PackageGuest key)
        {
            _context.PackageGuests.Remove(key);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<PackageGuest> Get(int key)
        {
            var result = await _context.PackageGuests.FirstOrDefaultAsync(s => s.BookingId == key);
            if (result != null)
                return result;
            return null;
        }

        public async Task<ICollection<PackageGuest>> GetAll()
        {
            var result = await _context.PackageGuests.ToListAsync();
            if (result != null)
                return result;
            return null;
        }

        public Task<PackageGuest> Update(PackageGuest item)
        {
            throw new NotImplementedException();
        }
    }
}
