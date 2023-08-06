using FeedBackAPI.Interfaces;
using FeedBackAPI.Models;
using FeedBackAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeedBackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageFBController : ControllerBase
    {
        private readonly IService<PackageFeedback, int, PackageDTO> _service;

        public PackageFBController(IService<PackageFeedback,int,PackageDTO> service)
        {
            _service=service;
        }


        [HttpPost("Add HotelFeedback")]
        [ProducesResponseType(typeof(PackageFeedback), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PackageFeedback>> AddPackage(PackageFeedback item)
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

        [HttpPost("Get OverAll PackageFeedback")]
        [ProducesResponseType(typeof(PackageDTO), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PackageDTO>> GetOverall(InputDTO item)
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


        [HttpPost("GetAll PackageFeedback ByPackageID")]
        [ProducesResponseType(typeof(PackageFeedback), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<PackageFeedback>>> GetAll(InputDTO item)
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
        [ProducesResponseType(typeof(PackageFeedback), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<PackageFeedback>>> GetAllByUser(InputDTO item)
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
