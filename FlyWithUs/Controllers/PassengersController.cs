using FlyWithUs.Hosted.Service.ApplicationService.IServices.Users;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
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
        private readonly ICountryService countryService;

        public PassengersController(IUserService userService, IUserContext userContext, ICountryService countryService)
        {
            this.userService = userService;
            this.userContext = userContext;
            this.countryService = countryService;
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
            string userid = userContext.UserId;
            var user = userService.GetUserForUserPanel(userid);
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
        [HttpPatch("ChangePassword")]
        public IActionResult ChangePassword([FromBody] ChangePasswordDTO dto)
        {
            dto.Id = userContext.UserId;
            var result = userService.ChangePassword(dto);
            return Ok(result);
        }


        [HttpGet("GetCountries")]
        public IActionResult GetCountries()
        {
            return Ok(countryService.GetAllCountryForUserPanel());
        }
    }
}
