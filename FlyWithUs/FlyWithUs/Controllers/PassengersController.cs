using FlyWithUs.Hosted.Service.ApplicationService.IServices.Users;
using FlyWithUs.Hosted.Service.DTOs.Users;
using FlyWithUs.Hosted.Service.Filter;
using FlyWithUs.Hosted.Service.Infrastructure.Common;
using FlyWithUs.Hosted.Service.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace FlyWithUs.Hosted.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IUserContext userContext;


        public PassengersController(IUserService userService, IUserContext userContext)
        {
            this.userService = userService;
            this.userContext = userContext;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterDTO dto)
        {
            userService.RegisterUser(dto);
            return Created("", "");
        }


        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO dto)
        {
            var token = userService.LoginUser(dto);
            return Ok(token);
        }


        [HttpPost("ForgotPassword")]
        public IActionResult ForgotPassword(ResetPasswordEmailDTO dto)
        {
            var result = userService.ForgotPassword(dto);
            return Ok(result);
        }


        [SecurityFilter(AuthorizationRoles.UserRole)]
        [HttpGet]
        public IActionResult GetUser()
        {
            var user = userService.GetUserForUserPanel(userContext.UserId);
            return Ok(user);
        }


        [SecurityFilter(AuthorizationRoles.UserRole)]
        [HttpGet("LoginCheck")]
        public IActionResult LoginCheck()
        {
            var result = userService.LoginCheck(userContext.UserId);
            return Ok(result);
        }


        [SecurityFilter(AuthorizationRoles.UserRole)]
        [HttpPut]
        public IActionResult Update([FromBody] UserProfileUpdateDTO dto)
        {
            dto.Id = userContext.UserId;
            var result = userService.Update(dto);
            return Ok(result);
        }


        [SecurityFilter(AuthorizationRoles.UserRole)]
        [HttpPatch("ChangePassword")]
        public IActionResult ChangePassword([FromBody] ChangePasswordDTO dto)
        {
            dto.Id = userContext.UserId;
            var result = userService.ChangePassword(dto);
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
