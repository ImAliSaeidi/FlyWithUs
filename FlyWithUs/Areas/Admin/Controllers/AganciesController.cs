using FlyWithUs.Hosted.Service.ApplicationService.Services.Airplanes;
using FlyWithUs.Hosted.Service.DTOs.Agancies;
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
        public AganciesController()
        {
            agancyService = new AgancyService();
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
        public IActionResult AddAgancy([FromForm]AgancyAddDTO dto)
        {
            if (ModelState.IsValid)
            {
                if (agancyService.IsAgancyExist(dto.Name, null)==true)
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
    }
}
