using FlyWithUs.Hosted.Service.ApplicationService.IServices.Travels;
using FlyWithUs.Hosted.Service.DTOs.Travels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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


        [HttpGet("{skip=0}/{take=2}/{origin}/{destination}/{movingdate}/{orderby}/")]
        public IActionResult GetAll(string origin, string destination, string movingdate, string orderby, [Required] int skip = 0, [Required] int take = 2)
        {
            var result = travelService.SearchTravel(skip, take,
                new TravelSearchDTO(movingdate)
                { Origin = origin, Destination = destination, OrderBy = orderby });
            return Ok(result);
        }


        [HttpGet("{travelid}")]
        public IActionResult GetTravel([Required] int travelid)
        {
            var result = travelService.GetTravelViewById(travelid);
            return Ok(result);
        }
    }
}
