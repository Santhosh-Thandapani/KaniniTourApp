using EndUserAPI.Interfaces;
using EndUserAPI.Models;
using EndUserAPI.Models.DTOs;
using EndUserAPI.Repositorys;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace EndUserAPI.Services
{
    public class ManageService : IService
    {
        private readonly IRepo<User> _repo;
        private readonly IBaseRepo<TourAgent> _agent;
        private readonly IBaseRepo<Passenger> _pass;
        private readonly IGenerateToken _tokenService;
        private readonly IAdapterService _adapterService;

        public ManageService(IRepo<User> repo,
                             IBaseRepo<TourAgent> agent,
                             IBaseRepo<Passenger> pass,
                             IAdapterService adapterService,
                             IGenerateToken tokenService)
        {
            _repo = repo;
            _agent = agent;
            _pass = pass;
            _tokenService = tokenService;
            _adapterService = adapterService;

        }

        public async Task<UserDTO> Login(UserDTO userDTO)
        {
            if (userDTO.PhoneNumber != null && userDTO.Password != null)
            {
                var doctorData = await _repo.GetByPhoneNo(userDTO.PhoneNumber);
                if (doctorData != null)
                {
                    if (doctorData.PasswordKey != null && doctorData.PasswordHash != null)
                    {
                        var hmac = new HMACSHA512(doctorData.PasswordKey);
                        var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                        for (int i = 0; i < userPass.Length; i++)
                        {
                            if (userPass[i] != doctorData.PasswordHash[i])
                                return null;
                        }
                        UserDTO user = new()
                        {
                            UserId = doctorData.UserId,
                            Status = doctorData.Status,
                            Role = doctorData.Role
                        };
                        user.Token = _tokenService.GenerateToken(user);
                        return user;
                    }
                }
            }
            return null;
        }

        public async Task<UserDTO> PassRegister(PassengerDTO passenger)
        {
            UserDTO userDTO = new();
            User user = _adapterService.PassengerDTOUserAdapter(passenger);
            var userResult = await _repo.Add(user);
            var PatientResult = await _pass.Add(passenger);
            if (userResult != null && PatientResult != null)
            {
                userDTO.UserId = userResult.UserId;
                userDTO.Role = userResult.Role;
                userDTO.Status = userResult.Status;
                userDTO.Token = _tokenService.GenerateToken(userDTO);
            }
            return userDTO;
        }

        public async Task<UserDTO> TourAgentRegister(TourAgentDTO tourAgent)
        {
            UserDTO userDTO = new();
            User user = _adapterService.TourAgentDTOUserAdapter(tourAgent);
            var userResult = await _repo.Add(user);
            var PatientResult = await _agent.Add(tourAgent);
            if (userResult != null && PatientResult != null)
            {
                userDTO.UserId = userResult.UserId;
                userDTO.Role = userResult.Role;
                userDTO.Status = userResult.Status;
                userDTO.Token = _tokenService.GenerateToken(userDTO);
            }
            return userDTO;
        }


        public async Task<UserDTO> UpdatePassword(InputDTO pass)
        {
            var user = await _repo.GetById(pass.Id);
            var hmac = new HMACSHA512();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pass.Password ?? "1234"));
            user.PasswordKey = hmac.Key;
            var result = await _repo.Update(user);
            UserDTO userDTO = new();
            if (result != null)
            {
                userDTO.UserId = result.UserId;
                userDTO.Role = result.Role;
                userDTO.Status = result.Status;
                userDTO.Token = _tokenService.GenerateToken(userDTO);
                return userDTO;
            }   
            return null;
        }

        public async Task<UserDTO> UpdatePhoneNo(InputDTO inUser)
        {
            var user = await _repo.GetById(inUser.Id);
            user.PhoneNo = inUser.PhoneNo;
            var result = await _repo.Update(user);
            UserDTO userDTO = new();
            if (result != null)
            {
                userDTO.UserId = result.UserId;
                userDTO.Role = result.Role;
                userDTO.Status = result.Status;
                userDTO.Token = _tokenService.GenerateToken(userDTO);
                return userDTO;
            }
            return null;
        }

        public async Task<UserDTO> UpdateStatus(InputDTO inUser)
        {
            var user = await _repo.GetById(inUser.Id);
            if (user != null){
                user.Status = "Approved";
                var result = await _repo.Update(user);
                UserDTO userDTO = new();
                if (result != null)
                {
                    userDTO.UserId = result.UserId;
                    userDTO.Role = result.Role;
                    userDTO.Status = result.Status;
                    userDTO.Token = _tokenService.GenerateToken(userDTO);
                    return userDTO;
                }
            }
            return null;
        }

        public async Task<bool> DeclineStatus(InputDTO inUser)
        {
            var agent = await _agent.Delete(inUser.Id);
            var user = await _repo.Delete(inUser.Id);
            if (user != null && agent!=null)
            {
                return true;
            }
            return false;
        }



        public async Task<ICollection<Passenger>> GetAllPassengers()
        {
            var list = await _pass.GetAll();
            if (list.Count > 0)
                return list;
            return null;
        }

        public async Task<ICollection<TourAgent>> GetApprovedTourAgents()
        {
            List<TourAgent> approvedTourAgents = new();
            var agents = await _agent.GetAll();
            var users = await _repo.GetAll();
            if (users != null)
            {
                var approvedAgentID = users.Where(s => s?.Role == "Tour Agent" && s.Status == "Approved").Select(p => p?.UserId).ToList();
                if (approvedAgentID.Count > 0 && agents != null)
                {
                    foreach (var id in approvedAgentID)
                    {
                        var doc = agents.SingleOrDefault(s => s?.TourAgentId == id);
                        if (doc != null)
                            approvedTourAgents.Add(doc);
                    }
                }
                return approvedTourAgents;
            }
            return null;
        }

        public async Task<ICollection<TourAgent>> GetNotApprovedTourAgents()
        {
            List<TourAgent> approvedTourAgents = new();
            var agents = await _agent.GetAll();
            var users = await _repo.GetAll();
            if (users != null)
            {
                var approvedAgentID = users.Where(s => s?.Role == "Tour Agent" && s.Status == "Not Approved").Select(p => p?.UserId).ToList();
                if (approvedAgentID.Count > 0 && agents != null)
                {
                    foreach (var id in approvedAgentID)
                    {
                        var doc = agents.SingleOrDefault(s => s?.TourAgentId == id);
                        if (doc != null)
                            approvedTourAgents.Add(doc);
                    }
                }
                return approvedTourAgents;
            }
            return null;
        }

        public async Task<Passenger> GetPassengerProfile(int id)
        {
            var profile = await _pass.GetById(id);
            if(profile != null)
                return profile;
            return null;
        }

        public async Task<TourAgent> GetTourAgentProfile(int id)
        {
            var profile = await _agent.GetById(id);
            if(profile != null) 
                return profile;
            return null;
        }
    }
}
