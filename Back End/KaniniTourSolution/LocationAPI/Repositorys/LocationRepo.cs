using LocationAPI.Interfaces;
using LocationAPI.Models;
using LocationAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace LocationAPI.Repositorys
{
    public class LocationRepo : IRepo
    {
        private DbTourLocationAPIContext _context;

        public LocationRepo(DbTourLocationAPIContext context) 
        {
            _context = context;
        }
        public async Task<ICollection<LocationDTO>> GetCities()
        {

            var cities = await _context.Cities.Where(state => state.StateName.ToLower() == "tamil nadu").Select(city => new LocationDTO { cityId = city.Id, cityName = city.Name }).ToListAsync();
            return cities;
        }

        public async Task<ICollection<City>> Get()
        {
            var city = await _context.Cities.ToListAsync();
            if (city != null)
                return city;
            return null;
        }

        public async Task<ICollection<State>> GetStates()
        {
            var states = await _context.States.ToListAsync();
            if (states != null)
                return states;
            return null;
        }
     
    }
}
