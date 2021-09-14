using FlyWithUs.Hosted.Service.ApplicationService.Services.World;
using FlyWithUs.Hosted.Service.DTOs.Airports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly CityService cityService;
        public AirportsController()
        {
            airportService = new AirportService();
            cityService = new CityService();
        }
        public IActionResult GetAllAirport()
        {
            List<AirportDTO> dtos = airportService.GetAllAirport();
            return View(dtos);
        }

        [HttpGet]
        public IActionResult AddAirport()
        {
            FillViewData();
            return View();
        }

        [HttpPost]
        public IActionResult AddAirport([FromForm] AirportAddDTO dto)
        {
            if (ModelState.IsValid)
            {
                if (airportService.IsAirportExist(dto.Name, dto.CityId, null) == true)
                {
                    ModelState.AddModelError("Name", "مشخصات وارد شده تکراری است");
                    FillViewData();
                    return View(dto);
                }
                else
                {
                    airportService.AddAirport(dto);
                    return Redirect("/Admin/Airports/GetAllAirport");
                }
            }
            else
            {
                FillViewData();
                return View();
            }
        }

        public IActionResult DeleteAirport(int id)
        {
            bool result = airportService.DeleteAirport(id);
            if (result == true)
            {
                return Redirect("/Admin/Airports/GetAllAirport");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult EditAirport(int id)
        {
            AirportUpdateDTO dto = airportService.GetAirportForUpdate(id);
            FillViewData();
            return View(dto);
        }

        [HttpPost]
        public IActionResult EditAirport([FromForm]AirportUpdateDTO dto)
        {
            if (ModelState.IsValid)
            {
                if (airportService.IsAirportExist(dto.Name, dto.CityId, dto.Id) == true)
                {
                    ModelState.AddModelError("Name", "مشخصات وارد شده تکراری است");
                    FillViewData();
                    return View(dto);
                }
                else
                {
                    airportService.UpdateAirport(dto);
                    return Redirect("/Admin/Airports/GetAllAirport");
                }
            }
            else
            {
                return View(dto);
            }
        }
        private void FillViewData()
        {
            var cities = cityService.GetAllCityAsSelectList();
            ViewData["Cities"] = new SelectList(cities, "Value", "Text");
        }
    }
}
