using HotelAPI.Interfaces;
using HotelAPI.Models;
using HotelAPI.Models.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AngularCORS")]
    public class HotelAmenityController : ControllerBase
    {
        private readonly IAmenityService<HotelAmenity> _service;

        public HotelAmenityController(IAmenityService<HotelAmenity> service)
        {
            _service=service;
        }


        [HttpPost("AddHotelAmenity")]
        [ProducesResponseType(typeof(HotelAmenity), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<HotelAmenity>> AddHotelAmenity(HotelAmenity item)
        {
            try
            {
                var addedAmenity= await _service.AddAmenity(item);
                if (addedAmenity == null)
                    return BadRequest("Unable to add Hotel");
                return Ok(addedAmenity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteHotelAmenity")]
        [ProducesResponseType(typeof(HotelAmenity), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<HotelAmenity>> DeleteHotel(HotelAmenity item)
        {
            try
            {
                var delHotelAmenity = await _service.RemoveAmenity(item);
                if (delHotelAmenity == null)
                    return BadRequest("Unable to delete Hotel");
                return Ok(delHotelAmenity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
