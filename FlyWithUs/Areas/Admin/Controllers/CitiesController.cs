using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Cities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class CitiesController : Controller
    {
        private readonly ICityService cityService;
        private readonly ICountryService countryService;

        public CitiesController(ICityService cityService, ICountryService countryService)
        {
            this.cityService = cityService;
            this.countryService = countryService;
        }


        [HttpGet("{skip=0}/{take=10}")]
        public IActionResult GetAllCity([Required] int skip = 0, [Required] int take = 10)
        {
            GridResultDTO<CityDTO> dto = cityService.GetAllCity(skip, take);
            return View(dto);
        }

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
                if (cityService.IsCityExist(dto.Name, dto.CountryId) == true)
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

        [HttpGet("{cityid}")]
        public IActionResult DeleteCity(int cityid)
        {
            bool result = cityService.DeleteCity(cityid);
            if (result == true)
            {
                return Redirect("/Admin/Cities/GetAllCity");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{cityid}")]
        public IActionResult EditCity(int cityid)
        {
            CityUpdateDTO dto = cityService.GetCityForUpdate(cityid);
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

        [HttpGet("{cityid}")]
        public IActionResult GetAirportForCity(int cityid)
        {
            CityDTO dto = cityService.GetCityById(cityid);
            return View(dto);
        }

        private void FillViewData()
        {
            var countries = countryService.GetAllCountryAsSelectList();
            ViewData["Countries"] = new SelectList(countries, "Value", "Text");
        }

    }
}
