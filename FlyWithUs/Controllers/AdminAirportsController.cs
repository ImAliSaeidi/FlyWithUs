using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using FlyWithUs.Hosted.Service.DTOs.Airports;
using FlyWithUs.Hosted.Service.Filter;
using FlyWithUs.Hosted.Service.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SecurityFilter(AuthorizationRoles.AdminRole)]
    public class AdminAirportsController : ControllerBase
    {
        private readonly IAirportService airportService;

        public AdminAirportsController(IAirportService airportService)
        {
            this.airportService = airportService;
        }


        [HttpGet("{skip=0}/{take=10}")]
        public IActionResult GetAllAirport([Required] int skip = 0, [Required] int take = 10)
        {
            var result = airportService.GetAllAirport(skip, take);
            return Ok(result);
        }

        [HttpGet("{airportId}")]
        public IActionResult GetAirport(int airportId)
        {
            var result = airportService.GetAirportById(airportId);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddAirport([FromBody] AirportAddDTO dto)
        {
            var result = airportService.AddAirport(dto);
            return Created("", result);
        }

        [HttpPatch]
        public IActionResult DeleteAirport([FromBody] AirportIdDTO dto)
        {
            var result = airportService.DeleteAirport(dto.Id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateAirport([FromBody] AirportUpdateDTO dto)
        {
            var result = airportService.UpdateAirport(dto);
            return Ok(result);
        }
    }
}
