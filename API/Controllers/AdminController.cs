using System.Threading.Tasks;
using API_Contracts.Models.Filters;
using API_Contracts.Models.PageModels;
using API_Contracts.Models.RequestModels;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController,Authorize(Roles = "admin")]   

    public class AdminController : Controller
    {
        private readonly IRequestService _requestService;
        public AdminController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpPost("removerequest/{id}")]
        public async Task<IActionResult> RemoveRequestAsync(string id)
        {
            var result = await _requestService.RemoveAsAdminAsync(id);
            return StatusCode(200, result.Message);
        }

        [HttpPost("requestsearch")]
        public async Task<IActionResult> RequestsSearchAsync([FromBody] PageRequestModel<AdminFilterModel> model)
        {
            //ObjectValidator.ValidateAndThrow(model);

            if (!ModelState.IsValid)
            {
                return StatusCode(400, "invalid data");
            }
            return StatusCode(200, await _requestService.AdminSearch(model));
        }

        [HttpPost("moderate")]
        public async Task<IActionResult> ModerateRequestAsync([FromBody] RequestModerationModel model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "invalid data");
            }

            var result = await _requestService.ModerateRequestAsync(model);
            return StatusCode(200, result.Message);
        }




    }
}