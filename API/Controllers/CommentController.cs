using System.Threading.Tasks;
using API_Contracts.Models.CommentModels;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController,Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateCommentAsync([FromBody] CommentModel model)
        {
            if (!ModelState.IsValid) return StatusCode(400, "Invalid model");
            var result = await _commentService.CreateAsync(model);
            return StatusCode(200, result);
        }

        //[HttpGet("Remove/{id}")]
        //public async Task<IActionResult> RemoveRequestOffer([FromHeader]string id)
        //{
        //    var result = await _commentService.RemoveAsyncAsUser(id);
        //    return StatusCode(200, result.Message);

        //}
    }
}