using EndUserAPI.Interfaces;
using EndUserAPI.Models;
using EndUserAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using System.Numerics;

namespace EndUserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AngularCORS")]
    public class EndUserController : ControllerBase
    {
        private readonly IService _service;
        private readonly ITwoFactorService _factor;

        public EndUserController(IService service , ITwoFactorService factor)
        {
            _service=service;
            _factor=factor;
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> Login(UserDTO userDTO)
        {
            try
            {
                var result = await _service.Login(userDTO);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return BadRequest("Please Check Credentials");
        }

        [HttpPost("TourAgent Register")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> TourAgentRegister(TourAgentDTO agent)
        {
            try
            {
                var result = await _service.TourAgentRegister(agent);
                var factor = await _factor.AddTwoFactor(result.UserId);
                if (result != null && factor !=null)
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return BadRequest("Unable to register at this moment");
        }

        [HttpPost("Passenger Register")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> PassengerRegister(PassengerDTO pass)
        {
            try
            {
                var result = await _service.PassRegister(pass);
                var factor = await _factor.AddTwoFactor(result.UserId);
                if (result != null && factor != null)
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return BadRequest("Unable to register at this moment");
        }

        [HttpPost("Check Two Factor")]
        [ProducesResponseType(typeof(UserTwoFactor), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<UserTwoFactor>>> CheckTwoFactor( TwoFactorDTO factor)
        {
            try
            {
                var resultFactor = await _factor.GetFactor(factor);
                if (resultFactor != null)
                {
                    return Ok(resultFactor);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return BadRequest("Unable to register at this moment");
        }


        [HttpPost("Show User TwoFactor")]
        [ProducesResponseType(typeof(UserTwoFactor), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<UserTwoFactor>>> ShowTwoFactor(InputDTO item)
        {
            try
            {
                var resultFactor = await _factor.GetAllFactor(item.Id);
                if (resultFactor != null )
                {
                    return Ok(resultFactor);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return BadRequest("Unable to register at this moment");
        }

        [HttpPut("Update Agent Status")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> UpdateAgentStatus(InputDTO input)
        {
            try
            {
                var result = await _service.UpdateStatus(input);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch (Exception up)
            {
                Debug.WriteLine(up);
            }
            return BadRequest("Unable to update status at this moment");
        }



        [HttpPut("Decline Agent")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeclineAgent(InputDTO input)
        {
            try
            {
                var result = await _service.DeclineStatus(input);
                if (result ==true)
                {
                    return Ok(result);
                }
            }
            catch (Exception up)
            {
                Debug.WriteLine(up);
            }
            return BadRequest("Unable to update status at this moment");
        }

        [HttpPut("Update Password")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> UpdatePassword(InputDTO input)
        {
            try
            {
                var result = await _service.UpdatePassword(input);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch (Exception up)
            {
                Debug.WriteLine(up);
            }
            return BadRequest("Unable to update status at this moment");
        }

        [HttpPut("Update phoneNO")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> UpdatePhoneNO(InputDTO input)
        {
            try
            {
                var result = await _service.UpdatePhoneNo(input);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch (Exception up)
            {
                Debug.WriteLine(up);
            }
            return BadRequest("Unable to update status at this moment");
        }


        [HttpGet("GetAll Passengers")]
        [ProducesResponseType(typeof(ICollection<Passenger?>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ICollection<Passenger?>>> GetAllPassgengers()
        {
            try
            {
                var result = await _service.GetAllPassengers();
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch (Exception nefe)
            {
                Debug.WriteLine(nefe);
            }
            return NotFound("Unable to update status at this moment");
        }


        [HttpGet("GetAll Approved Agents")]
        [ProducesResponseType(typeof(ICollection<TourAgent?>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ICollection<TourAgent?>>> GetAllApprovedAgents()
        {
            try
            {
                var result = await _service.GetApprovedTourAgents();
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch (Exception nefe)
            {
                Debug.WriteLine(nefe);
            }
            return NotFound("Unable to update status at this moment");
        }

        [HttpGet("GetAll NotApproved Agents")]
        [ProducesResponseType(typeof(ICollection<TourAgent?>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ICollection<TourAgent?>>> GetAllNotApprovedAgents()
        {
            try
            {
                var result = await _service.GetNotApprovedTourAgents();
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch (Exception nefe)
            {
                Debug.WriteLine(nefe);
            }
            return NotFound("Unable to update status at this moment");
        }


        [HttpPost("Passenger Profile")]
        [ProducesResponseType(typeof(Passenger), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Passenger>> PassengerProfile(InputDTO item)
        {
            try
            {
                var result = await _service.GetPassengerProfile(item.Id);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return BadRequest("Unable to register at this moment");
        }

        [HttpPost("Agent Profile")]
        [ProducesResponseType(typeof(TourAgent), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TourAgent>> AgentProfile(InputDTO item)
        {
            try
            {
                var result = await _service.GetTourAgentProfile(item.Id);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return BadRequest("Unable to register at this moment");
        }



    }
}
