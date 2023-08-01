using HotelAPI.Models;
using HotelAPI.Models.DTO;

namespace HotelAPI.Interfaces
{
    public interface IHotelService<T,K,S>
    {
        public Task<K> AddHotel(K hotel);
        public Task<T> UpdateHotel(T hotel);
        public Task<T> DeleteHotel(S id);
        public Task<K> GetHotel(S key);
        public Task<ICollection<K>> GetAllHotel();
    }
}
