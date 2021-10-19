using FlyWithUs.Hosted.Service.ApplicationService.IServices.Users;
using FlyWithUs.Hosted.Service.DTOs.User;
using FlyWithUs.Hosted.Service.DTOs.Users;
using FlyWithUs.Hosted.Service.Filter;
using FlyWithUs.Hosted.Service.Infrastructure.Common;
using FlyWithUs.Hosted.Service.Models;
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


        [SecurityFilter(AuthorizationRoles.UserRole)]
        [HttpGet("GetUser")]
        public IActionResult Get()
        {
            var user = userService.GetUserForUserPanel(userContext.UserId);
            return Ok(user);
        }


        [SecurityFilter(AuthorizationRoles.UserRole)]
        [HttpPut("Update")]
        public IActionResult Update([FromBody] UserUpdateDTO dto)
        {
            dto.Id = userContext.UserId;
            var result = userService.UpdateUser(dto);
            return Ok(result);
        }


        [SecurityFilter(AuthorizationRoles.UserRole)]
        [HttpPut("CompleteUserInfo")]
        public IActionResult CompleteUserInfo([FromBody] CompleteUserInfoDTO dto)
        {
            dto.Id = userContext.UserId;
            var result = userService.CompleteUserInfo(dto);
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

    }
}
