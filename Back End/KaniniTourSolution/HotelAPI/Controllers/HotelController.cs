using HotelAPI.Interfaces;
using HotelAPI.Models;
using HotelAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private IHotelService<Hotel, HotelDTO, int> _service;

        public HotelController(IHotelService<Hotel,HotelDTO,int> service)
        {
            _service=service;
        }

        [HttpPost("AddHotel")]
        [ProducesResponseType(typeof(Hotel),200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Hotel>> AddHotel(HotelDTO hotel)
        {
            try
            {
                Hotel newHotel =await _service.AddHotel(hotel);
                if (newHotel == null)
                    return BadRequest("Unable to add Hotel");
                return Ok( newHotel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteHotel")]
        [ProducesResponseType(typeof(Hotel), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Hotel>> DeleteHotel(InputDTO item)
        {
            try
            {
                Hotel delHotel = await _service.DeleteHotel(item.Id);
                if (delHotel == null)
                    return BadRequest("Unable to delete Hotel");
                return Ok(delHotel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetHotel")]
        [ProducesResponseType(typeof(Hotel), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<HotelDTO>> GetHotel(InputDTO item)
        {
            try
            {
                var hotel = await _service.GetHotel(item.Id);
                if (hotel == null)
                    return BadRequest("Unable to fetch Hotel");
                return Ok(hotel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllHotel")]
        [ProducesResponseType(typeof(Hotel), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<HotelDTO>>> GetAllHotel()
        {
            try
            {
                var hotels = await _service.GetAllHotel();
                if (hotels == null)
                    return BadRequest("Unable to fetch Hotels");
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateHotel")]
        [ProducesResponseType(typeof(Hotel), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Hotel>> UpdateHotel(Hotel item)
        {
            try
            {
                var hotel = await _service.GetHotel(item.Id);
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
