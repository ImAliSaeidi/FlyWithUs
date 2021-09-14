using FlyWithUs.Hosted.Service.ApplicationService.Services.World;
using FlyWithUs.Hosted.Service.DTOs.Countries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CountriesController : Controller
    {
        private readonly CountryService countryService;
        public CountriesController()
        {
            countryService = new CountryService();
        }
        public IActionResult GetAllCountry()
        {
            List<CountryDTO> dtos = countryService.GetAllCountry();
            return View(dtos);
        }
    }
}
