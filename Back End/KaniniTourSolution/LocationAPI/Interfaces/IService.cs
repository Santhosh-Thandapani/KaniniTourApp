using LocationAPI.Models;
using LocationAPI.Models.DTOs;

namespace LocationAPI.Interfaces
{
    public interface IService
    {
        public Task<ICollection<LocationDTO>> GetAllCities();
        public Task<ICollection<LocationDTO>> GetCities();
        public Task<LocationDTO> GetCityById(int id);
    }
}
