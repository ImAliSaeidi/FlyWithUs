using FlyWithUs.Hosted.Service.ApplicationService.IServices.Users;
using FlyWithUs.Hosted.Service.DTOs.Users;
using Microsoft.AspNetCore.Mvc;

namespace FlyWithUs.Hosted.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAdminsController : ControllerBase
    {
        private readonly IUserService userService;

        public AdminAdminsController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO dto)
        {
            var token = userService.LoginUser(dto);
            return Ok(token);
        }

        [HttpPost("ForgotPassword")]
        public IActionResult ForgotPassword([FromBody] ForgotPasswordDTO dto)
        {
            var result = userService.ForgotPassword(dto);
            return Ok(result);
        }

        [HttpPatch("ResetPassword")]
        public IActionResult ResetPassword([FromBody] ResetPasswordDTO dto)
        {
            var result = userService.ResetPassword(dto);
            return Ok(result);
        }
    }
}
