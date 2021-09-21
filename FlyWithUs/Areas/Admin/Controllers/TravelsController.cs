using FlyWithUs.Hosted.Service.ApplicationService.IServices.Airplanes;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.Travels;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using FlyWithUs.Hosted.Service.ApplicationService.Services.Travels;
using FlyWithUs.Hosted.Service.ApplicationService.Services.World;
using FlyWithUs.Hosted.Service.DTOs.Travels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TravelsController : Controller
    {
        private readonly ITravelService travelService;
        private readonly ICityService cityService;
        private readonly ICountryService countryService;
        private readonly IAirportService airportService;
        private readonly IAirplaneService airplaneService;
        private readonly IAgancyService agancyService;

        public TravelsController(ITravelService travelService,
            ICityService cityService,
            ICountryService countryService,
            IAirportService airportService,
            IAirplaneService airplaneService,
            IAgancyService agancyService)
        {
            this.travelService = travelService;
            this.cityService = cityService;
            this.countryService = countryService;
            this.airportService = airportService;
            this.airplaneService = airplaneService;
            this.agancyService = agancyService;
        }


        #region Get All Travel
        public IActionResult GetAllTravel()
        {
            List<TravelDTO> dtos = travelService.GetAllTravel();
            return View(dtos);
        }
        #endregion


        #region Add Travel
        [HttpGet]
        public IActionResult AddTravel()
        {
            FillViewData();
            return View();
        }

        [HttpPost]
        public IActionResult AddTravel([FromForm] TravelAddDTO dto)
        {
            if (ModelState.IsValid)
            {
                if (dto.OriginAirportId == dto.DestinationAirportId)
                {
                    ModelState.AddModelError("OriginCityId", "مبدا و مقصد نمیتواند یکسان باشد");
                    FillViewData();
                    return View(dto);
                }
                else
                {
                    travelService.AddTravel(dto);
                    return Redirect("/Admin/Travels/GetAllTravel");
                }
            }
            else
            {
                FillViewData();
                return View(dto);
            }
        }

        #endregion


        #region Delete Travel
        public IActionResult DeleteTravel(int id)
        {
            bool result = travelService.DeleteTravel(id);
            if (result == true)
            {
                return Redirect("/Admin/Travels/GetAllTravel");
            }
            else
            {
                return BadRequest();
            }
        }
        #endregion


        #region Edit Travel
        [HttpGet]
        public IActionResult EditTravel(int id)
        {
            TravelUpdateDTO dto = travelService.GetTravelForUpdate(id);
            FillViewData();
            return View(dto);
        }

        [HttpPost]
        public IActionResult EditTravel([FromForm] TravelUpdateDTO dto)
        {
            if (ModelState.IsValid)
            {
                if (dto.OriginAirportId == dto.DestinationAirportId)
                {
                    ModelState.AddModelError("OriginCityId", "مبدا و مقصد نمیتواند یکسان باشد");
                    FillViewData();
                    return View(dto);
                }
                else
                {
                    travelService.UpdateTravel(dto);
                    return Redirect("/Admin/Travels/GetAllTravel");
                }
            }
            else
            {
                FillViewData();
                return View(dto);
            }
        }
        #endregion


        #region Travel Info

        public IActionResult GetTravelInfo(int id)
        {
            var dto = travelService.GetTravelById(id);
            return View(dto);
        }

        #endregion


        #region Fill View Data Method
        private void FillViewData()
        {
            var countries = countryService.GetAllCountryAsSelectList();
            ViewData["Countries"] = new SelectList(countries, "Value", "Text");

            var cities = cityService.GetAllCityAsSelectList(Convert.ToInt32(countries.First().Value));
            ViewData["Cities"] = new SelectList(cities, "Value", "Text");

            var airports = airportService.GetAllAirportAsSelectList(Convert.ToInt32(cities.First().Value));
            ViewData["Airports"] = new SelectList(airports, "Value", "Text");

            var agancies = agancyService.GetAllAgancyAsSelectList();
            ViewData["Agancies"] = new SelectList(agancies, "Value", "Text");

            var airplanes = airplaneService.GetAllAirplaneAsSelectList(Convert.ToInt32(agancies.First().Value));
            ViewData["Airplanes"] = new SelectList(airplanes, "Value", "Text");

            var types = new List<SelectListItem>() {
                new SelectListItem
                {
                Text = "داخلی",
                Value = "داخلی"
                },
                new SelectListItem
                {
                Text = "خارجی",
                Value = "خارجی"
                }
            };
            ViewData["Types"] = new SelectList(types, "Value", "Text");

            var classes = new List<SelectListItem>() {
                new SelectListItem
                {
                Text = "اکونومی",
                Value = "اکونومی"
                },
                new SelectListItem
                {
                Text = "بیزینس کلاس",
                Value = "بیزینس کلاس"
                },
                new SelectListItem
                {
                Text = "فرست کلاس",
                Value = "فرست کلاس"
                }
            };
            ViewData["Classes"] = new SelectList(classes, "Value", "Text");
        }

        public IActionResult GetCities(int id)
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کنید",Value = ""}
            };
            list.AddRange(cityService.GetAllCityAsSelectList(id));
            return Json(new SelectList(list, "Value", "Text"));
        }

        public IActionResult GetAirports(int id)
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کنید",Value = ""}
            };
            list.AddRange(airportService.GetAllAirportAsSelectList(id));
            return Json(new SelectList(list, "Value", "Text"));
        }
        
        public IActionResult GetAirplanes(int id)
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کنید",Value = ""}
            };
            list.AddRange(airplaneService.GetAllAirplaneAsSelectList(id));
            return Json(new SelectList(list, "Value", "Text"));
        }
        #endregion


    }
}
