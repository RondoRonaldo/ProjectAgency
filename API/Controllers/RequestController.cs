using System.Threading.Tasks;
using API_Contracts.Models.Filters;
using API_Contracts.Models.PageModels;
using API_Contracts.Models.RequestModels;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Request manager endpoints
    /// </summary>
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

        /// <summary>
        /// Get request
        /// </summary>
        /// <param name="id">Request id</param>
        /// <returns>Request</returns>
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            return StatusCode(200, await _requestService.GetAsync(id));
        }

        /// <summary>
        /// Create request
        /// </summary>
        /// <param name="requestModel">Request to create</param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(RequestModel requestModel)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }
            await _requestService.CreateAsync(requestModel);

            return StatusCode(200);
        }

        /// <summary>
        /// Remove request
        /// </summary>
        /// <param name="id">Request id</param>
        /// <response code="200"></response>
        [HttpPost("delete/{id}")]
        public async Task<IActionResult> RemoveAsync([FromRoute] string id)
        {
            await _requestService.RemoveAsyncAsUser(id);
            return StatusCode(200);
        }

        /// <summary>
        /// Update request
        /// </summary>
        /// <param name="model">Request to update</param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] RequestUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }
            await _requestService.UpdateAsyncAsUser(model);
            return StatusCode(200);
        }

        /// <summary>
        /// Get user requests
        /// </summary>
        /// <returns>Requests</returns>
        [HttpGet("userrequests")]
        public async Task<IActionResult> UserRequestsAsync()
        {
            return StatusCode(200, await _requestService.GetUserRequestsAsync());
        }

        /// <summary>
        /// Create request
        /// </summary>
        /// <param name="id">Request id</param>
        /// <response code="200"></response>
        /// <returns>Result with commentaries</returns>
        [HttpGet("userrequests/{id}")]
        public async Task<IActionResult> UserRequestAsync([FromRoute] string id)
        {
            return StatusCode(200, await _requestService.GetRequestDetailsAsync(id));
        }

        /// <summary>
        /// Search requests with user rights
        /// </summary>
        /// <param name="model">Page information with filter parameters</param>
        /// <returns>Filtered requests</returns>
        [HttpPost("requestsearch")]
        public async Task<IActionResult> GetRequestsAsUserAsync([FromBody] PageRequestModel<UserFilterModel> model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            return StatusCode(200, await _requestService.UserSearch(model));
        }
    }
}