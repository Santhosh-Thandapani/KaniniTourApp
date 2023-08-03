using EndUserAPI.Models.DTOs;

namespace EndUserAPI.Interfaces
{
    public interface IGenerateToken
    {
        public string GenerateToken(UserDTO user);
    }
}
