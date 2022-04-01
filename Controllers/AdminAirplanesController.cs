using FlyWithUs.Hosted.Service.ApplicationService.IServices.Airplanes;
using FlyWithUs.Hosted.Service.DTOs.Airplanes;
using FlyWithUs.Hosted.Service.Filter;
using FlyWithUs.Hosted.Service.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SecurityFilter(AuthorizationRoles.AdminRole)]
    public class AdminAirplanesController : ControllerBase
    {
        private readonly IAirplaneService airplaneService;

        public AdminAirplanesController(IAirplaneService airplaneService)
        {
            this.airplaneService = airplaneService;
        }


        [HttpGet("{skip=0}/{take=10}")]
        public IActionResult GetAllAirplane([Required] int skip = 0, [Required] int take = 10)
        {
            var result = airplaneService.GetAllAirplane(skip, take);
            return Ok(result);
        }

        [HttpGet("{airplaneId}")]
        public IActionResult GetAirplane(int airplaneId)
        {
            var result = airplaneService.GetAirplaneById(airplaneId);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddAirplane([FromBody] AirplaneAddDTO dto)
        {
            var result = airplaneService.AddAirplane(dto);
            return Created("", result);
        }

        [HttpPatch]
        public IActionResult DeleteAirplane([FromBody] AirplaneIdDTO dto)
        {
            var result = airplaneService.DeleteAirplane(dto.Id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateAirplane([FromBody] AirplaneUpdateDTO dto)
        {
            var result = airplaneService.UpdateAirplane(dto);
            return Ok(result);
        }
    }
}
