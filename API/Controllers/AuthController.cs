using System.Threading.Tasks;
using API_Contracts.Models.UserModels;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Authentication
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Register using credentials
        /// </summary>
        /// <param name="model">User credentials</param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        [HttpPost("registration")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid) return StatusCode(400);

            await _userService.CreateAsync(model);

            return StatusCode(200);
        }

        /// <summary>
        /// Login using credentials
        /// </summary>
        /// <param name="model">User credentials</param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        [HttpPost("login")]
        public async Task<IActionResult> SignInAsync([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid) return StatusCode(400);
            await _userService.SignInAsync(model);
            return StatusCode(200);
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <response code="200"></response>
        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> LogOutAsync()
        {
            await _userService.SignOutAsync();
            return StatusCode(200);
        }
    }
}