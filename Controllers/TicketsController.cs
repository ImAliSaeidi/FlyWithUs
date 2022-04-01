using FlyWithUs.Hosted.Service.ApplicationService.IServices.Tickets;
using FlyWithUs.Hosted.Service.DTOs.Tickets;
using FlyWithUs.Hosted.Service.Filter;
using FlyWithUs.Hosted.Service.Infrastructure.Common;
using FlyWithUs.Hosted.Service.Models.Users;
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
        [HttpPost]
        public IActionResult AddTicket([FromBody] TicketAddDTO dto)
        {
            ticektService.AddTicket(dto, userContext.UserId);
            return Created("", "");
        }


        [SecurityFilter(AuthorizationRoles.UserRole)]
        [HttpPatch("DeleteTickets")]
        public IActionResult DeleteTickets()
        {
            var result = ticektService.DeleteTickets(userContext.UserId);
            return Ok(result);
        }

        [SecurityFilter(AuthorizationRoles.UserRole)]
        [HttpPatch("CancelTicket")]
        public IActionResult CancelTicket(TicketCancelDTO dto)
        {
            dto.UserId = userContext.UserId;
            var result = ticektService.CancelTicket(dto);
            return Ok(result);
        }

    }
}
