using FlyWithUs.Hosted.Service.ApplicationService.IServices.Airplanes;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Agancies;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class AganciesController : Controller
    {
        private readonly IAgancyService agancyService;

        public AganciesController(IAgancyService agancyService)
        {
            this.agancyService = agancyService;
        }


        [HttpGet("{skip=0}/{take=10}")]
        public IActionResult GetAllAgancy([Required] int skip = 0, [Required] int take = 10)
        {
            GridResultDTO<AgancyDTO> dto = agancyService.GetAllAgancy(skip, take);
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
                if (agancyService.IsAgancyExist(dto.Name.ToLower().Trim()) == true)
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

        [HttpGet("{agancyid}")]
        public IActionResult DeleteAgancy(int agancyid)
        {
            if (agancyService.DeleteAgancy(agancyid) == true)
            {
                return Redirect("/Admin/Agancies/GetAllAgancy");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{agancyid}")]
        public IActionResult EditAgancy(int agancyid)
        {
            var dto = agancyService.GetAgancyForUpdate(agancyid);
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

        [HttpGet("{agancyid}")]
        public IActionResult GetAirplaneForAgancy(int agancyid)
        {
            AgancyDTO dto = agancyService.GetAgancyById(agancyid);
            return View(dto);
        }

    }
}
