using FlyWithUs.Hosted.Service.ApplicationService.IServices.Orders;
using FlyWithUs.Hosted.Service.Filter;
using FlyWithUs.Hosted.Service.Infrastructure.Common;
using FlyWithUs.Hosted.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlyWithUs.Hosted.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IUserContext userContext;

        public OrdersController(IOrderService orderService, IUserContext userContext)
        {
            this.orderService = orderService;
            this.userContext = userContext;
        }


        [SecurityFilter(AuthorizationRoles.UserRole)]
        [HttpPost("Pay")]
        public IActionResult Pay()
        {
            var result = orderService.Pay(userContext.UserId);
            return Ok(result);
        }

        [SecurityFilter(AuthorizationRoles.UserRole)]
        [HttpPatch("DeleteNotFinalyOrders")]
        public IActionResult DeleteNotFinalyOrders()
        {
            var result = orderService.DeleteNotFinalyOrders(userContext.UserId);
            return Ok(result);
        }
    }
}
