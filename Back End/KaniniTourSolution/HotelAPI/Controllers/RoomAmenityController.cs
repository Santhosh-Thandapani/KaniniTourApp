using HotelAPI.Models.DTO;
using HotelAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelAPI.Interfaces;
using Microsoft.AspNetCore.Cors;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AngularCORS")]
    public class RoomAmenityController : ControllerBase
    {
        private readonly IAmenityService<RoomAmenity> _service;
        public RoomAmenityController(IAmenityService<RoomAmenity> service)
        {
            _service=service;
        }

        [HttpPost("AddRoomAmenity")]
        [ProducesResponseType(typeof(RoomAmenity), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RoomAmenity>> AddRoomAmenity(RoomAmenity item)
        {
            try
            {
                var newRoomAmenity = await _service.AddAmenity(item);
                if (newRoomAmenity == null)
                    return BadRequest("Unable to add Hotel");
                return Ok(newRoomAmenity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteRoomAmenity")]
        [ProducesResponseType(typeof(Hotel), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RoomAmenity>> DeleteRoomAmenity(RoomAmenity item)
        {
            try
            {
                var delRoomAmenity = await _service.RemoveAmenity(item);
                if (delRoomAmenity == null)
                    return BadRequest("Unable to delete Hotel");
                return Ok(delRoomAmenity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
