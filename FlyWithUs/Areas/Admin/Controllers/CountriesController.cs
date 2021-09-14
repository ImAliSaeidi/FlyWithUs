using FlyWithUs.Hosted.Service.ApplicationService.Services.World;
using FlyWithUs.Hosted.Service.DTOs.Countries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FlyWithUs.Hosted.Service.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CountriesController : Controller
    {
        private readonly CountryService countryService;
        public CountriesController()
        {
            countryService = new CountryService();
        }

        #region Get All Country
        public IActionResult GetAllCountry()
        {
            List<CountryDTO> dtos = countryService.GetAllCountry();
            return View(dtos);
        }
        #endregion


        #region Add Country
        [HttpGet]
        public IActionResult AddCountry()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCountry([FromForm] CountryAddDTO dto)
        {
            if (ModelState.IsValid)
            {
                if (countryService.IsExistCountry(dto.NiceName, dto.NumCode, dto.PhoneCode, null) == true)
                {
                    ModelState.AddModelError("NiceName", "مشخصات وارد شده تکراری است");
                    return View(dto);
                }
                else
                {
                    countryService.AddCountry(dto);
                    return Redirect("/Admin/Countries/GetAllCountry");
                }
            }
            else
            {
                return View(dto);
            }
        }
        #endregion


        #region Delete Country
        public IActionResult DeleteCountry(int id)
        {
            bool result = countryService.DeleteCountry(id);
            if (result == true)
            {
                return Redirect("/Admin/Countries/GetAllCountry");
            }
            else
            {
                return BadRequest();
            }
        }
        #endregion


        #region Edit Country
        [HttpGet]
        public IActionResult EditCountry(int id)
        {
            CountryUpdateDTO dto = countryService.GetCountryForUpdate(id);
            return View(dto);
        }

        [HttpPost]
        public IActionResult EditCountry([FromForm] CountryUpdateDTO dto)
        {
            if (ModelState.IsValid)
            {
                if (countryService.IsExistCountry(dto.NiceName, dto.NumCode, dto.PhoneCode, dto.Id) == true)
                {
                    ModelState.AddModelError("NiceName", "مشخصات وارد شده تکراری است");
                    return View(dto);
                }
                else
                {
                    countryService.UpdateCountry(dto);
                    return Redirect("/Admin/Countries/GetAllCountry");
                }
            }
            else
            {
                return View(dto);
            }
        }
        #endregion


        #region Get City For Country
        public IActionResult GetCityForCountry(int id)
        {
            CountryDTO dto = countryService.GetCountryById(id);
            return View(dto);
        }
        #endregion
    }
}