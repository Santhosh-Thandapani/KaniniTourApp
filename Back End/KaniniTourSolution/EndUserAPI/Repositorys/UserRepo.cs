using EndUserAPI.Interfaces;
using EndUserAPI.Models;
using EndUserAPI.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace EndUserAPI.Repositorys
{
    public class UserRepo : IRepo<User>
    {
        private readonly UserContext _context;

        public UserRepo(UserContext context)
        {
            _context=context;
        }
        public async Task<User> Add(User item)
        {
            _context.Users.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<User> Delete(int id)
        {
            var result = await GetById(id);
            if (result != null)
            {
                _context.Users.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<ICollection<User>> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            if (users != null)
                return users;
            return null;
        }

        public async Task<User> GetById(int id)
        {
            var result=await _context.Users.FirstOrDefaultAsync(s=>s.UserId==id);
            if (result != null)
                return result;
            return null;
        }

        public async Task<User> GetByPhoneNo(string pNo)
        {
            var result = await _context.Users.FirstOrDefaultAsync(s => s.PhoneNo==pNo);
            if (result != null)
                return result;
            return null;
        }

        public async Task<User> Update(User item)
        {
            var user = await GetById(item.UserId);
            if(user != null)
            {
                user.PhoneNo = item.PhoneNo;
                user.PasswordHash= item.PasswordHash;
                user.PasswordKey= item.PasswordKey;
                user.Status= item.Status;
                await _context.SaveChangesAsync();
                return user;
            }
            return null;
        }
    }
}
