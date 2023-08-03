using EndUserAPI.Interfaces;
using EndUserAPI.Models;
using EndUserAPI.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace EndUserAPI.Repositorys
{
    public class TourAgentRepo : IBaseRepo<TourAgent>
    {
        private readonly UserContext _context;

        public TourAgentRepo(UserContext context)
        {
            _context = context;
        }
        public async Task<TourAgent> Add(TourAgent item)
        {
            _context.TourAgents.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<TourAgent> Delete(int id)
        {
            var result = await GetById(id);
            if (result != null)
            {
                _context.TourAgents.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<ICollection<TourAgent>> GetAll()
        {
            var users = await _context.TourAgents.ToListAsync();
            if (users != null)
                return users;
            return null;
        }

        public async Task<TourAgent> GetById(int id)
        {
            var result = await _context.TourAgents.FirstOrDefaultAsync(s => s.TourAgentId == id);
            if (result != null)
                return result;
            return null;
        }

    }
}
