using EndUserAPI.Interfaces;
using EndUserAPI.Models;
using EndUserAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using System.Numerics;

namespace EndUserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EndUserController : ControllerBase
    {
        private readonly IService _service;

        public EndUserController(IService service)
        {
            _service=service;
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

        [HttpPost("Passenger Register")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> PatientRegister(PassengerDTO pass)
        {
            try
            {
                var result = await _service.PassRegister(pass);
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



    }
}
