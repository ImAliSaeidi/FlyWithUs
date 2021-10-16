using FlyWithUs.Hosted.Service.ApplicationService.IServices.Travels;
using FlyWithUs.Hosted.Service.DTOs.Travels;
using FlyWithUs.Hosted.Service.Filter;
using FlyWithUs.Hosted.Service.Infrastructure.Common;
using FlyWithUs.Hosted.Service.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelsController : ControllerBase
    {
        private readonly ITravelService travelService;
        private readonly IUserContext userContext;

        public TravelsController(ITravelService travelService, IUserContext userContext)
        {
            this.travelService = travelService;
            this.userContext = userContext;
        }


        [HttpGet("{skip=0}/{take=2}/{origin}/{destination}/{movingdate}/{backingdate?}")]
        public IActionResult GetAll(string origin, string destination, string movingdate, string backingdate, [Required] int skip = 0, [Required] int take = 2)
        {
            var result = travelService.SearchTravel(skip, take,
                new TravelSearchDTO(movingdate, backingdate)
                { Origin = origin, Destination = destination });
            return Ok(result);
        }


        [SecurityFilter(AuthorizationRoles.UserRole)]
        [HttpPost("{travelid}")]
        public IActionResult AddTicket(int travelid)
        {
            var userid = userContext.UserId;
            travelService.AddTicket(travelid, userid);
            return Created("", "");
        }
    }
}
