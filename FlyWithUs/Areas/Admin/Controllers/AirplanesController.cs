using FlyWithUs.Hosted.Service.ApplicationService.Services.Airplanes;
using FlyWithUs.Hosted.Service.DTOs.Airplanes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AirplanesController : Controller
    {
        private readonly AirplaneService airplaneService;
        public AirplanesController()
        {
            airplaneService = new AirplaneService();
        }
        public IActionResult GetAllAirplane()
        {
            List<AirplaneDTO> dtos = airplaneService.GetAllAirplane();
            return View(dtos);
        }
    }
}
