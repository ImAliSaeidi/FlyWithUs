using FlyWithUs.Hosted.Service.ApplicationService.IServices.Statistics;
using FlyWithUs.Hosted.Service.Filter;
using FlyWithUs.Hosted.Service.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace FlyWithUs.Hosted.Service.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [SecurityFilter(AuthorizationRoles.AdminRole)]
    public class AdminStatisticsController : ControllerBase
    {
        private readonly IStatisticsService statisticsService;

        public AdminStatisticsController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var result = statisticsService.GetStatistics();
            return Ok(result);
        }
    }
}
