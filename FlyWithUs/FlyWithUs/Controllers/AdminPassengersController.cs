using FlyWithUs.Hosted.Service.ApplicationService.IServices.Users;
using FlyWithUs.Hosted.Service.DTOs.Users;
using FlyWithUs.Hosted.Service.Filter;
using FlyWithUs.Hosted.Service.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SecurityFilter(AuthorizationRoles.AdminRole)]
    public class AdminPassengersController : ControllerBase
    {

        private readonly IUserService userService;

        public AdminPassengersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("{skip=0}/{take=10}")]
        public IActionResult GetAllUser([Required] int skip = 0, [Required] int take = 10)
        {
            var dto = userService.GetAllUser(skip, take);
            return Ok(dto);
        }

        [HttpGet("{userId}")]
        public IActionResult GetUser(string userId)
        {
            var result = userService.GetUserById(userId);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserAddDTO dto)
        {
            var result = userService.AddUser(dto);
            return Created("", "");
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserUpdateDTO dto)
        {
            var result = userService.UpdateUser(dto);
            return Ok(result);
        }

        [HttpPatch]
        public IActionResult DeleteUser([FromBody] UserIdDTO dto)
        {
            var result = userService.DeleteUser(dto.Id);
            return Ok(result);
        }
    }
}
