using FlyWithUs.Hosted.Service.ApplicationService.IServices.Travels;
using FlyWithUs.Hosted.Service.DTOs.Travels;
using FlyWithUs.Hosted.Service.Filter;
using FlyWithUs.Hosted.Service.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SecurityFilter(AuthorizationRoles.AdminRole)]
    public class AdminTravelsController : ControllerBase
    {
        private readonly ITravelService travelService;

        public AdminTravelsController(ITravelService travelService)
        {
            this.travelService = travelService;
        }



        [HttpGet("{skip=0}/{take=10}")]
        public IActionResult GetAllTravel([Required] int skip = 0, [Required] int take = 10)
        {
            var result = travelService.GetAllTravel(skip, take);
            return Ok(result);
        }

        [HttpGet("{travelId}")]
        public IActionResult GetTravel(int travelId)
        {
            var result = travelService.GetTravelById(travelId);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddTravel([FromBody] TravelAddDTO dto)
        {
            var result = travelService.AddTravel(dto);
            return Created("", result);
        }

        [HttpPatch]
        public IActionResult DeleteTravel([FromBody] TravelIdDTO dto)
        {
            var result = travelService.DeleteTravel(dto.Id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateTravel([FromBody] TravelUpdateDTO dto)
        {
            var result = travelService.UpdateTravel(dto);
            return Ok(result);
        }
    }
}
