using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using Microsoft.AspNetCore.Mvc;

namespace FlyWithUs.Hosted.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService countryService;

        public CountriesController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = countryService.GetAllCountryForAPI();
            return Ok(result);
        }
    }
}
