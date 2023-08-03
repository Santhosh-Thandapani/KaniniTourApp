using EndUserAPI.Interfaces;
using EndUserAPI.Models;
using EndUserAPI.Models.DTOs;
using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace EndUserAPI.Services
{
    public class AdapterService : IAdapterService
    {
        public User PassengerDTOUserAdapter(PassengerDTO pass)
        {
            try
            {
                if (pass != null)
                {
                    var hmac = new HMACSHA512();
                    if (pass.User != null)
                    {
                        pass.User.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pass.PasswordClear ?? "1234"));
                        pass.User.PasswordKey = hmac.Key;
                        pass.User.Role = "Passenger";
                        pass.User.Status = "Not Approved";
                        return pass.User;
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return null;
        }

        public User TourAgentDTOUserAdapter(TourAgentDTO agent)
        {
            try
            {
                if (agent != null)
                {
                    var hmac = new HMACSHA512();
                    if (agent.User != null)
                    {
                        agent.User.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(agent.PasswordClear ?? "1234"));
                        agent.User.PasswordKey = hmac.Key;
                        agent.User.Role = "Tour Agent";
                        agent.User.Status = "Not Approved";
                        return agent.User;
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return null;
        }
    }
}
