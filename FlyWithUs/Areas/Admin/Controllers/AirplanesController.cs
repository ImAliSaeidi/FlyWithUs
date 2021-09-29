using FlyWithUs.Hosted.Service.ApplicationService.IServices.Airplanes;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Airplanes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class AirplanesController : Controller
    {
        private readonly IAirplaneService airplaneService;
        private readonly IAgancyService agancyService;

        public AirplanesController(IAirplaneService airplaneService, IAgancyService agancyService)
        {
            this.airplaneService = airplaneService;
            this.agancyService = agancyService;
        }


        [HttpGet("{skip=0}/{take=10}")]
        public IActionResult GetAllAirplane([Required] int skip = 0, [Required] int take = 10)
        {
            GridResultDTO<AirplaneDTO> dto = airplaneService.GetAllAirplane(skip, take);
            return View(dto);
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

        [HttpGet("{airplaneid}")]
        public IActionResult DeleteAirplane(int airplaneid)
        {
            var result = airplaneService.DeleteAirplane(airplaneid);
            if (result == true)
            {
                return Redirect("/Admin/Airplanes/GetAllAirplane");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{airplaneid}")]
        public IActionResult EditAirplane(int airplaneid)
        {
            AirplaneUpdateDTO dto = airplaneService.GetAirplaneForUpdate(airplaneid);
            FillViewData();
            return View(dto);
        }

        [HttpPost]
        public IActionResult EditAirplane([FromForm] AirplaneUpdateDTO dto)
        {
            if (ModelState.IsValid)
            {
                if (airplaneService.IsAirplaneExist(dto.Name, dto.Brand, dto.MaxCapacity, dto.AgancyId, dto.Id) == true)
                {
                    ModelState.AddModelError("Name", "مشخصات وارد شده تکراری است");
                    FillViewData();
                    return View(dto);
                }
                else
                {
                    airplaneService.UpdateAirplane(dto);
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
            var agancies = agancyService.GetAllAgancyAsSelectList();
            ViewData["Agancies"] = new SelectList(agancies, "Value", "Text");
        }

    }
}
