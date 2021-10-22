using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using Microsoft.AspNetCore.Mvc;

namespace FlyWithUs.Hosted.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService cityService;

        public CitiesController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [HttpGet]
        public IActionResult GetPopularDestinations()
        {
            var result = cityService.GetPopularDestinations();
            return Ok(result);
        }
    }
}
