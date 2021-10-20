using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet("GetPopularDestinations")]
        public IActionResult GetPopularDestinations()
        {
            var result = cityService.GetPopularDestinations();
            return Ok(result);
        }
    }
}
