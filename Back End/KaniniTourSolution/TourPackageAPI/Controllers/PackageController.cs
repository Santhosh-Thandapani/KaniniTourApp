using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourPackageAPI.Interfaces;
using TourPackageAPI.Models;
using TourPackageAPI.Models.DTOs;

namespace TourPackageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IService<PackageDTO, int, Package> _service;

        public PackageController(IService<PackageDTO,int,Package> service)
        {
            _service = service;
        }

        [HttpPost("AddPackage")]
        [ProducesResponseType(typeof(PackageDTO), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PackageDTO>> AddPackage(PackageDTO item)
        {
            try
            {
                var addedPackage = await _service.Add(item);
                if (addedPackage == null)
                    return BadRequest("Unable to add Hotel");
                return Ok(addedPackage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeletePackage")]
        [ProducesResponseType(typeof(Package), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Package>> DeletePackage(InputDTO item)
        {
            try
            {
                var delPackage = await _service.DeletePackage(item.Id);
                if (delPackage == null)
                    return BadRequest("Unable to add Hotel");
                return Ok(delPackage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdatePackage")]
        [ProducesResponseType(typeof(Package), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Package>> UpdatePackage(Package item)
        {
            try
            {
                var updatePackage = await _service.UpdatePackage(item);
                if (updatePackage == null)
                    return BadRequest("Unable to add Hotel");
                return Ok(updatePackage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("GetPackage")]
        [ProducesResponseType(typeof(PackageDTO), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PackageDTO>> GetPackage(InputDTO item)
        {
            try
            {
                var package = await _service.GetPackage(item.Id);
                if (package == null)
                    return BadRequest("Unable to add Hotel");
                return Ok(package);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllPackage")]
        [ProducesResponseType(typeof(PackageDTO), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<PackageDTO>>> GetAllPackage()
        {
            try
            {
                var packages = await _service.GetAllPackages();
                if (packages == null)
                    return BadRequest("Unable to add Hotel");
                return Ok(packages);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
