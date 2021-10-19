using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Countries;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class CountriesController : Controller
    {
        private readonly ICountryService countryService;

        public CountriesController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [HttpGet("{skip=0}/{take=10}")]
        public IActionResult GetAllCountry([Required] int skip = 0, [Required] int take = 10)
        {
            GridResultDTO<CountryDTO> dtos = countryService.GetAllCountry(skip, take);
            return View(dtos);
        }

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
                if (countryService.IsExistCountry(dto.EnglishName, dto.PersianName) == true)
                {
                    ModelState.AddModelError("PersianName", "مشخصات وارد شده تکراری است");
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

        [HttpGet("{countryid}")]
        public IActionResult DeleteCountry(int countryid)
        {
            bool result = countryService.DeleteCountry(countryid);
            if (result == true)
            {
                return Redirect("/Admin/Countries/GetAllCountry");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{countryid}")]
        public IActionResult EditCountry(int countryid)
        {
            CountryUpdateDTO dto = countryService.GetCountryForUpdate(countryid);
            return View(dto);
        }

        [HttpPost]
        public IActionResult EditCountry([FromForm] CountryUpdateDTO dto)
        {
            if (ModelState.IsValid)
            {
                if (countryService.IsExistCountry(dto.EnglishName, dto.PersianName, dto.Id) == true)
                {
                    ModelState.AddModelError("PersianName", "مشخصات وارد شده تکراری است");
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

        [HttpGet("{countryid}")]
        public IActionResult GetCityForCountry(int countryid)
        {
            CountryDTO dto = countryService.GetCountryById(countryid);
            return View(dto);
        }

        [HttpGet("{countryid}")]
        public IActionResult GetAirportForCountry(int countryid)
        {
            CountryDTO dto = countryService.GetCountryById(countryid);
            return View(dto);
        }

    }
}