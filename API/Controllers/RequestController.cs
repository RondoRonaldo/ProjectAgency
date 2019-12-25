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
    [ApiController]
    [Authorize]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            return StatusCode(200, await _requestService.GetAsync(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(RequestModel requestModel)
        {
            if (!ModelState.IsValid) return StatusCode(400, "Invalid model");
            var result = await _requestService.CreateAsync(requestModel);

            return StatusCode(200, result.Message);
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> RemoveAsync([FromRoute] string id)
        {
            var result = await _requestService.RemoveAsyncAsUser(id);
            return StatusCode(200, result.Message);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] RequestUpdateModel model)
        {
            var result = await _requestService.UpdateAsyncAsUser(model);
            return StatusCode(200, result.Message);
        }


        [HttpGet("userrequests")]
        public async Task<IActionResult> UserRequestsAsync()
        {
            return StatusCode(200, await _requestService.GetUserRequestsAsync());
        }


        [HttpGet("userrequests/{id}")]
        public async Task<IActionResult> UserRequestAsync([FromRoute] string id)
        {
            return StatusCode(200, await _requestService.GetRequestDetailsAsync(id));
        }

        [HttpPost("requestsearch")]
        public async Task<IActionResult> GetRequestsAsUserAsync([FromBody] PageRequestModel<UserFilterModel> model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "invalid data");
            }

            return StatusCode(200, await _requestService.UserSearch(model));
        }
    }
}