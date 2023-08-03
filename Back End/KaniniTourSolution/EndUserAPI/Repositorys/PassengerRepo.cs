using EndUserAPI.Interfaces;
using EndUserAPI.Models;
using EndUserAPI.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace EndUserAPI.Repositorys
{
    public class PassengerRepo : IBaseRepo<Passenger>
    {
        private readonly UserContext _context;

        public PassengerRepo(UserContext context)
        {
            _context=context;
        }
        public async Task<Passenger> Add(Passenger item)
        {
            _context.Passengers.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Passenger> Delete(int id)
        {
            var result = await GetById(id);
            if (result != null)
            {
                _context.Passengers.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<ICollection<Passenger>> GetAll()
        {
            var users = await _context.Passengers.ToListAsync();
            if (users != null)
                return users;
            return null;
        }

        public async Task<Passenger> GetById(int id)
        {
            var result = await _context.Passengers.FirstOrDefaultAsync(s => s.PassId == id);
            if (result != null)
                return result;
            return null;
        }
    }
}
