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
        [HttpPost]
        public IActionResult Pay()
        {
            var result = orderService.Pay(userContext.UserId);
            return Ok(result);
        }

        [SecurityFilter(AuthorizationRoles.UserRole)]
        [HttpPatch]
        public IActionResult DeleteNotFinalyOrders()
        {
            var result = orderService.DeleteNotFinalyOrders(userContext.UserId);
            return Ok(result);
        }


        [SecurityFilter(AuthorizationRoles.UserRole)]
        [HttpGet]
        public IActionResult GetOrderDetails()
        {
            var result = orderService.GetOrderDetails(userContext.UserId);
            return Ok(result);
        }


        [SecurityFilter(AuthorizationRoles.UserRole)]
        [HttpGet("{skip}/{take}")]
        public IActionResult GetUserOrders(int skip, int take)
        {
            var result = orderService.GetUserOrder(userContext.UserId, skip, take);
            return Ok(result);
        }

    }
}
