using FlyWithUs.Hosted.Service.ApplicationService.Services.World;
using FlyWithUs.Hosted.Service.DTOs.Cities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CitiesController : Controller
    {
        private readonly CityService cityService;
        public CitiesController()
        {
            cityService = new CityService();
        }
        public IActionResult GetAllCity()
        {
            List<CityDTO> dtos = cityService.GetAllCity();
            return View(dtos);
        }
    }
}
