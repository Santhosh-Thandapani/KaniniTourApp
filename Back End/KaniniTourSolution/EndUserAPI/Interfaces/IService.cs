using EndUserAPI.Models;
using EndUserAPI.Models.DTOs;

namespace EndUserAPI.Interfaces
{
    public interface IService
    {
        public Task<UserDTO> Login(UserDTO user);
        public Task<UserDTO> PassRegister(PassengerDTO passenger);
        public Task<UserDTO> TourAgentRegister(TourAgentDTO tourAgent);
        public Task<UserDTO> UpdatePhoneNo(InputDTO user);
        public Task<UserDTO> UpdateStatus(InputDTO user);
        public Task<UserDTO> UpdatePassword(InputDTO pass);
        public Task<ICollection<Passenger>> GetAllPassengers();
        public Task<ICollection<TourAgent>> GetApprovedTourAgents();
        public Task<ICollection<TourAgent>> GetNotApprovedTourAgents();
    }
}
