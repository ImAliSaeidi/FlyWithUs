using FlyWithUs.Hosted.Service.ApplicationService.IServices.Tickets;
using FlyWithUs.Hosted.Service.DTOs.Tickets;
using FlyWithUs.Hosted.Service.Filter;
using FlyWithUs.Hosted.Service.Infrastructure.Common;
using FlyWithUs.Hosted.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlyWithUs.Hosted.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IUserContext userContext;
        private readonly ITicektService ticektService;

        public TicketsController(IUserContext userContext, ITicektService ticektService)
        {
            this.userContext = userContext;
            this.ticektService = ticektService;
        }


        [SecurityFilter(AuthorizationRoles.UserRole)]
        [HttpPost("AddTicket")]
        public IActionResult AddTicket([FromBody] TicketAddDTO dto)
        {
            ticektService.AddTicket(dto, userContext.UserId);
            return Created("", "");
        }

    }
}
