using FlyWithUs.Hosted.Service.ApplicationService.Services.World;
using FlyWithUs.Hosted.Service.DTOs.Cities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly CountryService countryService;
        public CitiesController()
        {
            cityService = new CityService();
            countryService = new CountryService();
        }
        public IActionResult GetAllCity()
        {
            List<CityDTO> dtos = cityService.GetAllCity();
            return View(dtos);
        }

        [HttpGet]
        public IActionResult AddCity()
        {
            FillViewData();
            return View();
        }
        [HttpPost]
        public IActionResult AddCity([FromForm] CityAddDTO dto)
        {
            if (ModelState.IsValid)
            {
                if (cityService.IsCityExist(dto.Name, dto.CountryId, null) == true)
                {
                    ModelState.AddModelError("Name", "مشخصات وارد شده تکراری است");
                    FillViewData();
                    return View(dto);
                }
                else
                {
                    cityService.AddCity(dto);
                    return Redirect("/Admin/Cities/GetAllCity");
                }
            }
            else
            {
                FillViewData();
                return View(dto);
            }
        }

        private void FillViewData()
        {
            var countries = countryService.GetAllCountryAsSelectList();
            ViewData["Countries"] = new SelectList(countries, "Value", "Text");
        }

        public IActionResult DeleteCity(int id)
        {
            bool result = cityService.DeleteCity(id);
            if (result == true)
            {
                return Redirect("/Admin/Cities/GetAllCity");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
