using LocationAPI.Interfaces;
using LocationAPI.Models;
using LocationAPI.Models.DTOs;

namespace LocationAPI.Services
{
    public class AdapterServicecs : IAdapter
    {
        public LocationDTO CityToOutputDTO(City item)
        {
            LocationDTO output = new LocationDTO();
            output.cityId=item.Id; 
            output.cityName=item.Name;
            output.StateId=item.StateId;
            output.StateName=item.StateName;
            output.CountryId=item.CountryId;
            output.CountryName=item.CountryName;
            return output;
        }
    }
}
