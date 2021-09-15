using FlyWithUs.Hosted.Service.ApplicationService.Services.Travels;
using FlyWithUs.Hosted.Service.DTOs.Travels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TravelsController : Controller
    {
        private readonly TravelService travelService;
        public TravelsController()
        {
            travelService = new TravelService();
        }
        public IActionResult GetAllTravel()
        {
            List<TravelDTO> dtos = travelService.GetAllTravel();
            return View(dtos);
        }
    }
}
