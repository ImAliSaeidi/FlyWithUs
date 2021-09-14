using FlyWithUs.Hosted.Service.ApplicationService.Services.World;
using FlyWithUs.Hosted.Service.DTOs.Airports;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AirportsController : Controller
    {
        private readonly AirportService airportService;
        public AirportsController()
        {
            airportService = new AirportService();
        }
        public IActionResult GetAllAirport()
        {
            List<AirportDTO> dtos = airportService.GetAllAirport();
            return View(dtos);
        }
    }
}
