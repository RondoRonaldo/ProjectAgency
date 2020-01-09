using System.Threading.Tasks;
using API_Contracts.Models.DistrictModels;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Test manager endpoints
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DistrictController : Controller
    {
        private readonly IDistrictService _districtService;

        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        /// <summary>
        /// Create district
        /// </summary>
        /// <param name="model">District to be created</param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        [Authorize(Roles = "admin")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(DistrictModel model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }
            await _districtService.CreateAsync(model);
            return StatusCode(200);
        }

        /// <summary>
        /// Update district
        /// </summary>
        /// <param name="model">District to be updated</param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        [Authorize(Roles = "admin")]
        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(DistrictDashboardModel model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }
            await _districtService.UpdateAsync(model);
            return StatusCode(200);
        }

        /// <summary>
        /// Get district
        /// </summary>
        ///<returns>District</returns>>
      
        [HttpGet("get")]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _districtService.GetAsync();
            return StatusCode(200, result);
        }

        /// <summary>
        /// Delete district
        /// </summary>
        /// <param name="id">District id</param>
        /// <response code="200"></response>
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        {
            await _districtService.RemoveAsync(id);
            return StatusCode(200);
        }
    }
}