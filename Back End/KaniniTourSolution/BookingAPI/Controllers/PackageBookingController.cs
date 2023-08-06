using BookingAPI.Interfaces;
using BookingAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageBookingController : ControllerBase
    {
        private readonly IBookingService<PackageBookDTO, int, CancelDTO> _service;
        public PackageBookingController(IBookingService<PackageBookDTO, int, CancelDTO> service)
        {
            _service = service;
        }

        [HttpPost("Book Package")]
        [ProducesResponseType(typeof(PackageBookDTO), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PackageBookDTO>> AddHotel(PackageBookDTO item)
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
        [ProducesResponseType(typeof(PackageBookDTO), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<PackageBookDTO>>> GetAll()
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
        [ProducesResponseType(typeof(PackageBookDTO), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<PackageBookDTO>>> GetAllByUserId(InputDTO item)
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
