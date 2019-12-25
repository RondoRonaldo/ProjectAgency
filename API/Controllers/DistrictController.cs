using System.Threading.Tasks;
using API_Contracts.Models.DistrictModels;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
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

        [Authorize(Roles = "admin")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(DistrictModel model)
        {
            if (!ModelState.IsValid) return StatusCode(400, "Invalid model");
            var result = await _districtService.CreateAsync(model);
            return StatusCode(200, result.Message);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(DistrictDashboardModel model)
        {
            if (!ModelState.IsValid) return StatusCode(400, "Invalid model");
            var result = await _districtService.UpdateAsync(model);
            return StatusCode(200, result.Message);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _districtService.GetAsync();
            return StatusCode(200, result);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        {
            var result = await _districtService.RemoveAsync(id);
            return StatusCode(200, result.Message);
        }
    }
}