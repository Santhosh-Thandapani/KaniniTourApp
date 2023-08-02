using LocationAPI.Interfaces;
using LocationAPI.Models;
using LocationAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IService _service;

        public LocationController(IService service)
        {
            _service =service;
        }

        [HttpGet("GetAllLocationAdapter")]
        [ProducesResponseType(typeof(LocationDTO), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<LocationDTO>>> GetAllLocation()
        {
            try
            {
                var locations = await _service.GetAllCities();
                if (locations == null)
                    return BadRequest("Unable to fetch locations");
                return Ok(locations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get")]
        [ProducesResponseType(typeof(City), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<City>>> GetCities()
        {
            try
            {
                var locations = await _service.GetCities();
                if (locations == null)
                    return BadRequest("Unable to fetch locations");
                return Ok(locations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
