using Microsoft.AspNetCore.Mvc;
using Solicity.Domain.Entities;
using Solicity.Domain.Services;

namespace Solicity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IAuthService _authService;
        private IUserService _userService;

        public UsersController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            try
            {
                var newUser = new User();

                newUser.FirstName = "Sample";
                newUser.LastName = "Sample2";
                newUser.Email = "sample@gmail.com";
                newUser.Password = "Password@123";
                newUser.Enabled = true;

                var user = await _userService.RegisterUser(newUser);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}