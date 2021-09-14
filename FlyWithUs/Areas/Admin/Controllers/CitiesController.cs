using FlyWithUs.Hosted.Service.ApplicationService.Services.World;
using FlyWithUs.Hosted.Service.DTOs.Cities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

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

        #region Get All City
        public IActionResult GetAllCity()
        {
            List<CityDTO> dtos = cityService.GetAllCity();
            return View(dtos);
        }
        #endregion


        #region Add City
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
        #endregion


        #region Fill View Data Method
        private void FillViewData()
        {
            var countries = countryService.GetAllCountryAsSelectList();
            ViewData["Countries"] = new SelectList(countries, "Value", "Text");
        }
        #endregion


        #region Delete City
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
        #endregion


        #region Edit City
        [HttpGet]
        public IActionResult EditCity(int id)
        {
            CityUpdateDTO dto = cityService.GetCityForUpdate(id);
            FillViewData();
            return View(dto);
        }

        [HttpPost]
        public IActionResult EditCity([FromForm] CityUpdateDTO dto)
        {
            if (ModelState.IsValid)
            {
                if (cityService.IsCityExist(dto.Name, dto.CountryId, dto.Id) == true)
                {
                    ModelState.AddModelError("Name", "مشخصات وارد شده تکراری است");
                    FillViewData();
                    return View(dto);
                }
                else
                {
                    cityService.UpdateCity(dto);
                    return Redirect("/Admin/Cities/GetAllCity");
                }
            }
            else
            {
                FillViewData();
                return View(dto);
            }
        }
        #endregion
    }
}
