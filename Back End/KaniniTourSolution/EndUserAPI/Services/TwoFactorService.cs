using EndUserAPI.Interfaces;
using EndUserAPI.Models;
using EndUserAPI.Models.DTOs;

namespace EndUserAPI.Services
{
    public class TwoFactorService : ITwoFactorService
    {
        private readonly IBaseRepo<UserTwoFactor> _repo;
        private readonly IRepo<User> _userRepo;

        public TwoFactorService(IBaseRepo<UserTwoFactor> repo,IRepo<User> userRepo)
        {
            _repo = repo;
            _userRepo = userRepo;
        }
        public async Task<ICollection<UserTwoFactor>> AddTwoFactor(int id)
        {
            Random random = new Random();
            var length = 5;
            const string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            for (int k = 0; k < 5; k++)
            {
                UserTwoFactor item = new UserTwoFactor();
                var result = "";
                for (int i = 0; i < length; i++)
                {
                    result += alphabet[random.Next(alphabet.Length)];
                }
                item.userId = id;
                item.String= result;
                await _repo.Add(item);
            }
            var AllList= await _repo.GetAll();
            var list= AllList.Where(s=>s.Id==id).ToList();
            if (list.Count() > 0)
                return list;
            return null;
        }

        public async Task<UserTwoFactor> DeleteTwoFactor(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<UserTwoFactor>> GetAllFactor(int id)
        {
            var AllList = await _repo.GetAll();
            var list = AllList.Where(s => s.userId == id).ToList();
            if (list.Count() > 0)
                return list;
            return null;
        }

        public async Task<UserTwoFactor> GetFactor(TwoFactorDTO item)
        {
            var user = await _userRepo.GetByPhoneNo(item.PhoneNumber);
            var AllList = await _repo.GetAll();
            var lists = AllList.Where(s => s.Id == user.UserId).ToList();
            foreach(var i in lists)
            {
                if (i.String == item.String)
                    return i;
            }
            return null;
        }
    }
}
