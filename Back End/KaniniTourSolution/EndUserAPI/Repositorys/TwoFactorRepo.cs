using EndUserAPI.Interfaces;
using EndUserAPI.Models;
using EndUserAPI.Models.Context;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EndUserAPI.Repositorys
{
    public class TwoFactorRepo : IBaseRepo<UserTwoFactor>
    {
        private readonly UserContext _context;

        public TwoFactorRepo(UserContext context)
        {
            _context = context;
        }
        public async Task<UserTwoFactor> Add(UserTwoFactor item)
        {
            _context.UserTwoFactors.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<UserTwoFactor> Delete(int id)
        {
           var item = await GetById(id);
            _context.UserTwoFactors.Remove(item);
            await  _context.SaveChangesAsync();
            return item;

        }

        public async Task<ICollection<UserTwoFactor>> GetAll()
        {
            var items = await _context.UserTwoFactors.ToListAsync();
            if (items.Count > 0)
                return items;
            return null;
        }

        public async Task<UserTwoFactor> GetById(int id)
        {
            var item =await _context.UserTwoFactors.FirstOrDefaultAsync(s => s.userId == id);
            if (item != null)
                return item;
            return null;
        }
    }
}
