using FlyWithUs.Hosted.Service.ApplicationService.IServices.Users;
using FlyWithUs.Hosted.Service.DTOs.APIs.User;
using FlyWithUs.Hosted.Service.DTOs.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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

        [HttpGet("{userid}")]
        public IActionResult Get([Required] int userid)
        {
            var user = userService.GetUserById(userid);
            return Ok(user);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UserUpdateDTO dto)
        {
            var result = userService.UpdateUser(dto);
            return Ok(result);
        }
    }
}
