using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using FlyWithUs.Hosted.Service.DTOs.Cities;
using FlyWithUs.Hosted.Service.Filter;
using FlyWithUs.Hosted.Service.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SecurityFilter(AuthorizationRoles.AdminRole)]
    public class AdminCitiesController : ControllerBase
    {
        private readonly ICityService cityService;

        public AdminCitiesController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [HttpGet("{skip=0}/{take=10}")]
        public IActionResult GetAllCity([Required] int skip = 0, [Required] int take = 10)
        {
            var dto = cityService.GetAllCity(skip, take);
            return Ok(dto);
        }

        [HttpGet("{cityId}")]
        public IActionResult GetCity(int cityId)
        {
            var result = cityService.GetCityById(cityId);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCity([FromBody] CityAddDTO dto)
        {
            var result = cityService.AddCity(dto);
            return Created("", result);
        }

        [HttpPatch]
        public IActionResult DeleteCity([FromBody] CityIdDTO dto)
        {
            var result = cityService.DeleteCity(dto.Id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateCity([FromBody] CityUpdateDTO dto)
        {
            var result = cityService.UpdateCity(dto);
            return Ok(result);
        }
    }
}
