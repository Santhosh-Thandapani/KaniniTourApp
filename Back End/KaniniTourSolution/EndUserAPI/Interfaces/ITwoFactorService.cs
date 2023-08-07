using EndUserAPI.Models;
using EndUserAPI.Models.DTOs;

namespace EndUserAPI.Interfaces
{
    public interface ITwoFactorService
    {
        public Task<ICollection<UserTwoFactor>> AddTwoFactor(int id);

        public Task<ICollection<UserTwoFactor>> GetAllFactor(int id);
        public Task<UserTwoFactor> DeleteTwoFactor(int id);
        public Task<UserTwoFactor> GetFactor(TwoFactorDTO item);
    }
}
