using LocationAPI.Interfaces;
using LocationAPI.Models;
using LocationAPI.Models.DTOs;

namespace LocationAPI.Services
{
    public class LocationService : IService
    {
        private readonly IRepo _repo;
        private readonly IAdapter _adapter;

        public LocationService(IRepo repo,IAdapter adapter) 
        {
            _repo = repo;
            _adapter=adapter;
        }

        public async Task<ICollection<LocationDTO>> GetAllCities()
        {
            List<LocationDTO> cities = new List<LocationDTO>();
            var getcities= await _repo.Get();
            foreach (var city in getcities)
            {
                var getCity = _adapter.CityToOutputDTO(city);
                cities.Add(getCity);
            }
            if (cities.Count > 0)
                return cities;
            return null;
        }

        public async Task<ICollection<LocationDTO>> GetCities()
        {
            var getcities = await _repo.GetCities();
            if (getcities != null)
                return getcities;
            return null;
        }

    }
}
