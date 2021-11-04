using FlyWithUs.Hosted.Service.ApplicationService.IServices.Airplanes;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Agancies;
using FlyWithUs.Hosted.Service.Filter;
using FlyWithUs.Hosted.Service.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SecurityFilter(AuthorizationRoles.AdminRole)]
    public class AdminAganciesController : ControllerBase
    {
        private readonly IAgancyService agancyService;

        public AdminAganciesController(IAgancyService agancyService)
        {
            this.agancyService = agancyService;
        }


        [HttpGet("{skip=0}/{take=10}")]
        public IActionResult GetAllAgancy([Required] int skip = 0, [Required] int take = 10)
        {
            GridResultDTO<AgancyDTO> dto = agancyService.GetAllAgancy(skip, take);
            return Ok(dto);
        }

        [HttpGet("{agancyId}")]
        public IActionResult GetAgancy(int agancyId)
        {
            var result = agancyService.GetAgancyById(agancyId);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllAgancyForDropDown()
        {
            var result = agancyService.GetAllAgancyAsSelectList();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddAgancy([FromBody] AgancyAddDTO dto)
        {
            var result = agancyService.AddAgancy(dto);
            return Created("", result);
        }

        [HttpPatch]
        public IActionResult DeleteAgancy([FromBody] AgancyIdDTO dto)
        {
            var result = agancyService.DeleteAgancy(dto.Id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateAgancy([FromBody] AgancyUpdateDTO dto)
        {
            var result = agancyService.UpdateAgancy(dto);
            return Ok(result);
        }
    }
}
