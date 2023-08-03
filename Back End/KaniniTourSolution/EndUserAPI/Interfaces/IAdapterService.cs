using EndUserAPI.Models;
using EndUserAPI.Models.DTOs;

namespace EndUserAPI.Interfaces
{
    public interface IAdapterService
    {
        public User PassengerDTOUserAdapter(PassengerDTO pass);
        public User TourAgentDTOUserAdapter(TourAgentDTO agent);
    }
}
