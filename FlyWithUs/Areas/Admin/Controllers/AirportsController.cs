using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Airports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class AirportsController : Controller
    {
        private readonly IAirportService airportService;
        private readonly ICityService cityService;

        public AirportsController(IAirportService airportService, ICityService cityService)
        {
            this.airportService = airportService;
            this.cityService = cityService;
        }


        [HttpGet("{skip=0}/{take=10}")]
        public IActionResult GetAllAirport([Required] int skip = 0, [Required] int take = 10)
        {
            GridResultDTO<AirportDTO> dto = airportService.GetAllAirport(skip, take);
            return View(dto);
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
                if (airportService.IsAirportExist(dto.PersianName, dto.CityId) == true)
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

        [HttpGet("{airportid}")]
        public IActionResult DeleteAirport(int airportid)
        {
            bool result = airportService.DeleteAirport(airportid);
            if (result == true)
            {
                return Redirect("/Admin/Airports/GetAllAirport");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{airportid}")]
        public IActionResult EditAirport(int airportid)
        {
            AirportUpdateDTO dto = airportService.GetAirportForUpdate(airportid);
            FillViewData();
            return View(dto);
        }

        [HttpPost]
        public IActionResult EditAirport([FromForm] AirportUpdateDTO dto)
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
            var cities = cityService.GetAllCityAsSelectList(null);
            ViewData["Cities"] = new SelectList(cities, "Value", "Text");
        }
    }
}
