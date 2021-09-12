using FlyWithUs.Hosted.Service.ApplicationService.Services.Airplanes;
using FlyWithUs.Hosted.Service.DTOs.Agancies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AganciesController : Controller
    {
        private readonly AgancyService agancyService;
        public AganciesController()
        {
            agancyService = new AgancyService();
        }
        public IActionResult GetAllAgancy()
        {
            List<AgancyDTO> dto = agancyService.GetAllAgancy();
            return View(dto);
        }
    }
}
