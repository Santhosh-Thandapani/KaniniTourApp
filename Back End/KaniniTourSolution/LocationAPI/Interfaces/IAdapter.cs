using LocationAPI.Models;
using LocationAPI.Models.DTOs;

namespace LocationAPI.Interfaces
{
    public interface IAdapter
    {
        public LocationDTO CityToOutputDTO(City item);
    }
}
