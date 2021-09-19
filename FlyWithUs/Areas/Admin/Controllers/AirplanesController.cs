using FlyWithUs.Hosted.Service.ApplicationService.IServices.Airplanes;
using FlyWithUs.Hosted.Service.ApplicationService.Services.Airplanes;
using FlyWithUs.Hosted.Service.DTOs.Airplanes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FlyWithUs.Hosted.Service.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AirplanesController : Controller
    {
        private readonly IAirplaneService airplaneService;
        private readonly IAgancyService agancyService;

        public AirplanesController(IAirplaneService airplaneService, IAgancyService agancyService)
        {
            this.airplaneService = airplaneService;
            this.agancyService = agancyService;
        }



        #region Get All Airplane
        public IActionResult GetAllAirplane()
        {
            List<AirplaneDTO> dtos = airplaneService.GetAllAirplane();
            return View(dtos);
        }
        #endregion


        #region Add Airplane
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
        #endregion


        #region Delete Airplane
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
        #endregion


        #region Edit Airplane
        [HttpGet]
        public IActionResult EditAirplane(int id)
        {
            AirplaneUpdateDTO dto = airplaneService.GetAirplaneForUpdate(id);
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
        #endregion


        #region Fill View Data Method
        private void FillViewData()
        {
            var agancies = agancyService.GetAllAgancyAsSelectList();
            ViewData["Agancies"] = new SelectList(agancies, "Value", "Text");
        }
        #endregion
    }
}
