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
    /// Admin management
    /// </summary>
    [Route("api/[controller]")]
    [ApiController,Authorize(Roles = "admin")]   

    public class AdminController : Controller
    {
        private readonly IRequestService _requestService;
        private readonly ICommentService _commentService;
        public AdminController(IRequestService requestService, ICommentService commentService)
        {
            _requestService = requestService;
            _commentService = commentService;
        }

        /// <summary>
        /// Remove request
        /// </summary>
        /// <param name="id">Request id</param>
        /// <response code="200"></response>
        [HttpPost("removerequest/{id}")]
        public async Task<IActionResult> RemoveRequestAsync(string id)
        {
            await _requestService.RemoveAsAdminAsync(id);
            return StatusCode(200);
        }

        /// <summary>
        /// Search requests with admin rights
        /// </summary>
        /// <param name="model">Page information with filter parameters</param>
        /// <returns>Filtered requests</returns>
        [HttpPost("requestsearch")]
        public async Task<IActionResult> RequestsSearchAsync([FromBody] PageRequestModel<AdminFilterModel> model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }
            return StatusCode(200, await _requestService.AdminSearch(model));
        }

        /// <summary>
        /// Moderate request
        /// </summary>
        /// <param name="model">Moderation model</param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        [HttpPost("moderate")]
        public async Task<IActionResult> ModerateRequestAsync([FromBody] RequestModerationModel model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            await _requestService.ModerateRequestAsync(model);
            return StatusCode(200);
        }

        /// <summary>
        /// Remove request
        /// </summary>
        /// <param name="id">Comment id</param>
        /// <response code="200"></response>
        [HttpDelete("removecomment/{id}")]
        public async Task<IActionResult> RemoveCommentAsync([FromHeader] string id)
        {
            await _commentService.RemoveAsAdminAsync(id);
            return StatusCode(200);
        }
    }
}