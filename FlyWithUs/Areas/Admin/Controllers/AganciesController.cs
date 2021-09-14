using FlyWithUs.Hosted.Service.ApplicationService.Services.Airplanes;
using FlyWithUs.Hosted.Service.DTOs.Agancies;
using FlyWithUs.Hosted.Service.DTOs.Airplanes;
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
        private readonly AirplaneService airplaneService;
        public AganciesController()
        {
            agancyService = new AgancyService();
            airplaneService = new AirplaneService();
        }
        public IActionResult GetAllAgancy()
        {
            List<AgancyDTO> dto = agancyService.GetAllAgancy();
            return View(dto);
        }

        [HttpGet]
        public IActionResult AddAgancy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAgancy([FromForm] AgancyAddDTO dto)
        {
            if (ModelState.IsValid)
            {
                if (agancyService.IsAgancyExist(dto.Name, null) == true)
                {
                    ModelState.AddModelError("Name", "نام وارد شده معتبر نیست");
                    return View(dto);
                }
                else
                {
                    agancyService.AddAgancy(dto);
                    return Redirect("/Admin/Agancies/GetAllAgancy");
                }
            }
            else
            {
                return View(dto);
            }
        }

        public IActionResult DeleteAgancy(int id)
        {
            if (agancyService.DeleteAgancy(id) == true)
            {
                return Redirect("/Admin/Agancies/GetAllAgancy");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult EditAgancy(int id)
        {
            var dto = agancyService.GetAgancyForUpdate(id);
            return View(dto);
        }

        [HttpPost]
        public IActionResult EditAgancy([FromForm] AgancyUpdateDTO dto)
        {
            if (ModelState.IsValid)
            {
                if (agancyService.IsAgancyExist(dto.Name, dto.Id) == true)
                {
                    ModelState.AddModelError("Name", "نام وارد شده معتبر نیست");
                    return View(dto);
                }
                else
                {
                    agancyService.UpdateAgancy(dto);
                    return Redirect("/Admin/Agancies/GetAllAgancy");
                }
            }
            else
            {
                return View(dto);
            }
        }

        public IActionResult GetAirplaneForAgancy(int id)
        {
            AgancyDTO dto = agancyService.GetAgancyById(id);
            return View(dto);
        }
    }
}
