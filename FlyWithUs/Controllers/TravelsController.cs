using FlyWithUs.Hosted.Service.ApplicationService.IServices.Travels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelsController : ControllerBase
    {
        private readonly ITravelService travelService;

        public TravelsController(ITravelService travelService)
        {
            this.travelService = travelService;
        }

        [HttpGet("{skip=0}/{take=10}")]
        public IActionResult GetAll([Required] int skip=0, [Required] int take=10)
        {
            var result = travelService.GetAllTravel(skip, take);
            return Ok(result);
        }
    }
}
