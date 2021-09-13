using FlyWithUs.Hosted.Service.ApplicationService.Services.Airplanes;
using FlyWithUs.Hosted.Service.DTOs.Agancies;
using FlyWithUs.Hosted.Service.DTOs.Airplanes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly AgancyService agancyService;
        public AirplanesController()
        {
            airplaneService = new AirplaneService();
            agancyService = new AgancyService();
        }
        public IActionResult GetAllAirplane()
        {
            List<AirplaneDTO> dtos = airplaneService.GetAllAirplane();
            return View(dtos);
        }

        [HttpGet]
        public IActionResult AddAirplane()
        {
            FillViewData();
            return View();
        }

        [HttpPost]
        public IActionResult AddAirplane([FromForm] AirplaneAddDTO dto)
        {
            if (ModelState.IsValid)
            {
                if (airplaneService.IsAirplaneExist(dto.Name, dto.Brand, dto.MaxCapacity, dto.AgancyId, null) == true)
                {
                    ModelState.AddModelError("Name", "مشخصات وارد شده تکراری است");
                    FillViewData();
                    return View(dto);
                }
                else
                {
                    airplaneService.AddAirplane(dto);
                    return Redirect("/Admin/Airplanes/GetAllAirplane");
                }
            }
            else
            {
                return View(dto);
            }
        }
        private void FillViewData()
        {
            var agancies = agancyService.GetAllAgancyForAddAirplane();
            ViewData["Agancies"] = new SelectList(agancies, "Value", "Text");
        }

        public IActionResult DeleteAirplane(int id)
        {
            var result = airplaneService.DeleteAirplane(id);
            if (result == true)
            {
                return Redirect("/Admin/Airplanes/GetAllAirplane");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
