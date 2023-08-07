using BookingAPI.Interfaces;
using BookingAPI.Models.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Hosting;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AngularCORS")]
    public class HotelBookingController : ControllerBase
    {
        private readonly IBookingService<HotelBookDTO, int, CancelDTO> _service;

        public HotelBookingController(IBookingService<HotelBookDTO,int,CancelDTO> service)
        {
            _service=service;
        }

        [HttpPost("Book Hotel")]
        [ProducesResponseType(typeof(HotelBookDTO), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<HotelBookDTO>> AddHotel(HotelBookDTO item)
        {
            try
            {
                var booking = await _service.AddBooking(item);
                if (booking == null)
                    return BadRequest("Unable to add Hotel");
                return Ok(booking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Cancel Booking")]
        [ProducesResponseType(typeof(CancelDTO), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CancelDTO>> DeleteHotel(InputDTO item)
        {
            try
            {
                var delBooking = await _service.RemoveBooking(item.Id);
                if (delBooking == null)
                    return BadRequest("Unable to delete Hotel");
                return Ok(delBooking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll Booking")]
        [ProducesResponseType(typeof(HotelBookDTO), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<HotelBookDTO>>> GetAll()
        {
            try
            {
                var hotels = await _service.GetAllBooking();
                if (hotels == null)
                    return BadRequest("Unable to fetch Hotels");
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost("GetAll Booking")]
        [ProducesResponseType(typeof(HotelBookDTO), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<HotelBookDTO>>> GetAllByUserId(InputDTO item)
        {
            try
            {
                var hotels = await _service.GetBookingsByUser(item.Id);
                if (hotels == null)
                    return BadRequest("Unable to fetch Hotels");
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
