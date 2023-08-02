using LocationAPI.Models;
using LocationAPI.Models.DTOs;

namespace LocationAPI.Interfaces
{
    public interface IRepo
    {
        public Task<ICollection<LocationDTO>> GetCities();
        public Task<ICollection<State>> GetStates();
        public Task<ICollection<City>> Get();
    }
}
