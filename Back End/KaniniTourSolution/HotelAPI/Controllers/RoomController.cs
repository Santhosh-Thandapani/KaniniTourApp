using HotelAPI.Interfaces;
using HotelAPI.Models.DTO;
using HotelAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AngularCORS")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService<RoomDTO, Room, int> _service;

        public RoomController(IRoomService<RoomDTO, Room, int> service)
        {
            _service=service;
        }


        [HttpPost("AddRoom")]
        [ProducesResponseType(typeof(RoomDTO), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RoomDTO>> AddRoom(RoomDTO room)
        {
            try
            {
                var newRoom = await _service.AddRoom(room);
                if (newRoom == null)
                    return BadRequest("Unable to add Room");
                return Ok(newRoom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteRoom")]
        [ProducesResponseType(typeof(RoomDTO), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RoomDTO>> DeleteHotel(InputDTO item)
        {
            try
            {
                var delRoom = await _service.RemoveRoom(item.Id);
                if (delRoom == null)
                    return BadRequest("Unable to delete Room");
                return Ok(delRoom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("GetRooms")]
        [ProducesResponseType(typeof(RoomDTO), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<RoomDTO>>> GetRooms(InputDTO item)
        {
            try
            {
                var hotel = await _service.GetRoomsByHotel(item.Id);
                if (hotel == null)
                    return BadRequest("Unable to fetch Hotel");
                return Ok(hotel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateRoom")]
        [ProducesResponseType(typeof(Room), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Room>> UpdateRoom(Room item)
        {
            try
            {
                var hotel = await _service.UpdateRoom(item);
                if (hotel == null)
                    return BadRequest("Unable to fetch Hotel");
                return Ok(hotel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
