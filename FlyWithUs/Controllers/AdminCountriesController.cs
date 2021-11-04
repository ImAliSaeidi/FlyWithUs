using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using FlyWithUs.Hosted.Service.DTOs.Countries;
using FlyWithUs.Hosted.Service.Filter;
using FlyWithUs.Hosted.Service.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SecurityFilter(AuthorizationRoles.AdminRole)]
    public class AdminCountriesController : ControllerBase
    {
        private readonly ICountryService countryService;

        public AdminCountriesController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [HttpGet("{skip=0}/{take=10}")]
        public IActionResult GetAllCountry([Required] int skip = 0, [Required] int take = 10)
        {
            var result = countryService.GetAllCountry(skip, take);
            return Ok(result);
        }

        [HttpGet("{countryId}")]
        public IActionResult GetCountry(int countryId)
        {
            var result = countryService.GetCountryById(countryId);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCountry([FromBody] CountryAddDTO dto)
        {
            var result = countryService.AddCountry(dto);
            return Created("", result);
        }

        [HttpGet]
        public IActionResult GetAllWithoutPaging()
        {
            var result = countryService.GetAllWithoutPaging();
            return Ok(result);
        }

        [HttpPatch]
        public IActionResult DeleteCountry([FromBody]CountryIdDTO dto)
        {
            var result = countryService.DeleteCountry(dto.Id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateCountry([FromBody] CountryUpdateDTO dto)
        {
            var result = countryService.UpdateCountry(dto);
            return Ok(result);
        }
    }
}
