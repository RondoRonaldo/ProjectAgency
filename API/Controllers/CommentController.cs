using System.Threading.Tasks;
using API_Contracts.Models.CommentModels;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Comment endpoints
    /// </summary>
    [Route("api/[controller]")]
    [ApiController,Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        /// <summary>
        /// Create new comment
        /// </summary>
        /// <param name="model">Comment model</param>
        /// <returns>New comment</returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateCommentAsync([FromBody] CommentModel model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }
            var result = await _commentService.CreateAsync(model);
            return StatusCode(200, result);
        }

        /// <summary>
        /// Create new comment
        /// </summary>
        /// <param name="id">Comment id</param>
        /// <response code="400"></response>
        /// <response code="200"></response>
        [HttpPost("remove/{id}")]
        public async Task<IActionResult> RemoveCommentAsync([FromHeader] string id)
        {
            await _commentService.RemoveAsUserAsync(id);
            return StatusCode(200);
        }
        

    }
}