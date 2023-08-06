using BookingAPI.Interfaces;
using BookingAPI.Models;
using BookingAPI.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Repositorys
{
    public class PackageBookRepo : IRepo<PackageBook, int>
    {
        private readonly BookingContext _context;

        public PackageBookRepo(BookingContext context)
        {
            _context = context;
        }
        public async Task<PackageBook> Add(PackageBook item)
        {
            _context.PackageBooks.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<PackageBook> Delete(PackageBook item)
        {
            _context.PackageBooks.Remove(item);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<PackageBook> Get(int key)
        {
            var result = await _context.PackageBooks.FirstOrDefaultAsync(s => s.BookingId == key);
            if (result != null)
                return result;
            return null;
        }

        public async Task<ICollection<PackageBook>> GetAll()
        {
            var result = await _context.PackageBooks.ToListAsync();
            if (result != null)
                return result;
            return null;
        }
        public Task<PackageBook> Update(PackageBook item)
        {
            throw new NotImplementedException();
        }
    }

}
