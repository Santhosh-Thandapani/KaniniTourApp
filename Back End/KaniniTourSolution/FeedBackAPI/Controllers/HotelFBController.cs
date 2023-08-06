using FeedBackAPI.Interfaces;
using FeedBackAPI.Models;
using FeedBackAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeedBackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelFBController : ControllerBase
    {
        private readonly IService<HotelFeedback, int, HotelDTO> _service;

        public HotelFBController(IService<HotelFeedback,int,HotelDTO> service)
        {
            _service=service;
        }

        [HttpPost("Add HotelFeedback")]
        [ProducesResponseType(typeof(HotelFeedback), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<HotelFeedback>> AddPackage(HotelFeedback item)
        {
            try
            {
                var addedfeedback = await _service.AddFeedback(item);
                if (addedfeedback == null)
                    return BadRequest("Unable to add Hotel feedback");
                return Ok(addedfeedback);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Get OverAll HotellFeedback")]
        [ProducesResponseType(typeof(HotelDTO), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<HotelDTO>> GetOverall(InputDTO item)
        {
            try
            {
                var feedback = await _service.OverAllFeedback(item.Id);
                if (feedback == null)
                    return BadRequest("Unable to add Hotel");
                return Ok(feedback);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("GetAll Feedback ByHotelID")]
        [ProducesResponseType(typeof(HotelFeedback), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<HotelFeedback>>> GetAll(InputDTO item)
        {
            try
            {
                var feedbacks = await _service.GetAll(item.Id);
                if (feedbacks == null)
                    return BadRequest("Unable to add Hotel");
                return Ok(feedbacks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("GetAll Feedback ByUserId")]
        [ProducesResponseType(typeof(HotelFeedback), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<HotelFeedback>>> GetAllByUser(InputDTO item)
        {
            try
            {
                var feedbacks = await _service.GetAllByUser(item.Id);
                if (feedbacks == null)
                    return BadRequest("Unable to add Hotel");
                return Ok(feedbacks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
