using System.Threading.Tasks;
using API_Contracts.Models.UserModels;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("registration")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid) return StatusCode(400, "Invalid Model");

            var result = await _userService.CreateAsync(model);

            return StatusCode(result.Succeeded ? 200 : 400, result.Message);
        }


        [HttpPost("login")]
        public async Task<IActionResult> SignInAsync([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid) return StatusCode(400, "Wrong parameters");
            var result = await _userService.SignInAsync(model);
            return StatusCode(result.Succeeded ? 200 : 401);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> LogOutAsync()
        {
            await _userService.SignOutAsync();
            return StatusCode(200);
        }
    }
}