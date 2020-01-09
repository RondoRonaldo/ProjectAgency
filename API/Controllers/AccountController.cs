using System.Threading.Tasks;
using API_Contracts.Models.UserModels;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Profile management
    /// </summary>
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class AccountController : Controller
    {        
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Change password 
        /// </summary>
        /// <param name="changePassword">Password model</param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        [HttpPost("password")]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] PasswordModel changePassword)
        {

            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }
            await _userService.ChangePasswordAsync(changePassword);
            return StatusCode(200);
        }

        /// <summary>
        /// Get user information
        /// </summary>
        /// <returns>User information</returns>
        [HttpGet("info")]
        public async Task<IActionResult> GetUserInfoAsync()
        {
            return StatusCode(200, await _userService.GetPersonalInfoAsync());                
        }

        /// <summary>
        /// Update user profile
        /// </summary>
        /// <param name="model">User profile to be updated</param>
        /// <response code="200"></response>
        /// <response code="400"></response>
        [HttpPost("update")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }
            await _userService.UpdateAsync(model);
            return StatusCode(200);
        }

        /// <summary>
        /// Get user information
        /// </summary>
        /// <returns>User profile information</returns>
        [HttpGet("get")]
        public async Task<IActionResult> GetUserAsync()
        {
            return StatusCode(200, await _userService.GetProfileModelAsync());
        }

    }
}
