using FlyWithUs.Hosted.Service.ApplicationService.IServices.Users;
using FlyWithUs.Hosted.Service.DTOs.APIs.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlyWithUs.Hosted.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengersController : ControllerBase
    {
        private readonly IUserService userService;

        public PassengersController(IUserService userService)
        {
            this.userService = userService;
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
    }
}
