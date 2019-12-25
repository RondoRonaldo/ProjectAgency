using System.Threading.Tasks;
using API_Contracts.Models.UserModels;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class AccountController : Controller
    {        
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("password")]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] PasswordModel changePassword)
        {

            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Invalid Data");
            }
            
            return StatusCode(200, (await _userService.ChangePasswordAsync(changePassword)).Message);
        }

        [HttpGet("info")]
        public async Task<IActionResult> GetUserInfoAsync()
        {
            return StatusCode(200, await _userService.GetPersonalInfoAsync());                
        }
        
        [HttpPost("update")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Invalid Data");
            }
            var result = await _userService.UpdateAsync(model);
            return StatusCode(200, result.Message);
        }


        [HttpGet("get")]
        public async Task<IActionResult> GetUserAsync()
        {
            return StatusCode(200, await _userService.GetProfileModelAsync());
        }

    }
}
