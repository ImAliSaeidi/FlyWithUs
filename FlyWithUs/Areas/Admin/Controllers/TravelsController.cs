using FlyWithUs.Hosted.Service.ApplicationService.IServices.Airplanes;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.Travels;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Travels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
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



        [HttpGet("{skip=0}/{take=10}")]
        public IActionResult GetAllTravel(int skip = 0, int take = 10)
        {
            GridResultDTO<TravelViewDTO> dto = travelService.GetAllTravel(skip, take);
            return View(dto);
        }

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
                var airplane = airplaneService.GetAirplaneById(dto.AirplaneId);
                if (dto.OriginAirportId == dto.DestinationAirportId)
                {
                    ModelState.AddModelError("OriginCityId", "مبدا و مقصد نمیتواند یکسان باشد");
                    FillViewData();
                    return View(dto);
                }
                else if (airplane.MaxCapacity < dto.MaxCapacity)
                {
                    string errormessage = "ظرفیت وارد شده مجاز نیست،حداکثر" + "(" + airplane.MaxCapacity + ")";
                    ModelState.AddModelError("MaxCapacity", errormessage);
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

        [HttpGet("{travelid}")]
        public IActionResult DeleteTravel(int travelid)
        {
            bool result = travelService.DeleteTravel(travelid);
            if (result == true)
            {
                return Redirect("/Admin/Travels/GetAllTravel");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{travelid}")]
        public IActionResult EditTravel(int travelid)
        {
            TravelUpdateDTO dto = travelService.GetTravelForUpdate(travelid);
            FillViewData(dto);
            return View(dto);
        }

        [HttpPost]
        public IActionResult EditTravel([FromForm] TravelUpdateDTO dto)
        {
            if (ModelState.IsValid)
            {
                if (dto.OriginAirportId == dto.DestinationAirportId)
                {
                    ModelState.AddModelError("OriginAirportId", "مبدا و مقصد نمیتواند یکسان باشد");
                    FillViewData();
                    return View(dto);
                }
                else if (dto.MaxCapacity <= dto.SoldTicket)
                {
                    ModelState.AddModelError("MaxCapacity", "حداکثر ظرفیت نمیتواند کمتر از بلیط های فروش رفته باشد");
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

        [HttpGet("{travelid}")]
        public IActionResult GetTravelInfo(int travelid)
        {
            var dto = travelService.GetTravelById(travelid);
            return View(dto);
        }

        private void FillViewData(TravelUpdateDTO dto)
        {
            var countries = countryService.GetAllCountryAsSelectList();
            ViewData["OriginCountries"] = new SelectList(countries, "Value", "Text", dto.OriginCountryId);
            ViewData["DestinationCountries"] = new SelectList(countries, "Value", "Text", dto.DestinationCountryId);

            var origincities = cityService.GetAllCityAsSelectList(dto.OriginCountryId);
            var destinationcities = cityService.GetAllCityAsSelectList(dto.DestinationCountryId);
            ViewData["OriginCities"] = new SelectList(origincities, "Value", "Text", dto.OriginCityId);
            ViewData["DestinationCities"] = new SelectList(destinationcities, "Value", "Text", dto.DestinationCityId);

            var originairports = airportService.GetAllAirportAsSelectList(dto.OriginCityId);
            var destinationairports = airportService.GetAllAirportAsSelectList(dto.DestinationCityId);
            ViewData["OriginAirports"] = new SelectList(originairports, "Value", "Text", dto.OriginAirportId);
            ViewData["DestinationAirports"] = new SelectList(destinationairports, "Value", "Text", dto.DestinationAirportId);

            var agancies = agancyService.GetAllAgancyAsSelectList();
            ViewData["Agancies"] = new SelectList(agancies, "Value", "Text", dto.AgancyId);

            var airplanes = airplaneService.GetAllAirplaneAsSelectList(dto.AgancyId);
            ViewData["Airplanes"] = new SelectList(airplanes, "Value", "Text", dto.AirplaneId);

            var classes = new List<SelectListItem>() {
                new SelectListItem
                {
                Text = "اکونومی",
                Value = "Economy"
                },
                new SelectListItem
                {
                Text = "بیزینس کلاس",
                Value = "Business"
                },
                new SelectListItem
                {
                Text = "فرست کلاس",
                Value = "First"
                }
            };
            ViewData["Classes"] = new SelectList(classes, "Value", "Text");
        }

        private void FillViewData()
        {
            var countries = countryService.GetAllCountryAsSelectList();
            ViewData["Countries"] = new SelectList(countries, "Value", "Text", countries[1].Value);

            var cities = cityService.GetAllCityAsSelectList(Convert.ToInt32(countries[1].Value));
            ViewData["Cities"] = new SelectList(cities, "Value", "Text");

            var airports = airportService.GetAllAirportAsSelectList(Convert.ToInt32(cities.First().Value));
            ViewData["Airports"] = new SelectList(airports, "Value", "Text");

            var agancies = agancyService.GetAllAgancyAsSelectList();
            ViewData["Agancies"] = new SelectList(agancies, "Value", "Text");

            var airplanes = airplaneService.GetAllAirplaneAsSelectList(Convert.ToInt32(agancies.First().Value));
            ViewData["Airplanes"] = new SelectList(airplanes, "Value", "Text");

            var classes = new List<SelectListItem>() {
                new SelectListItem
                {
                Text = "اکونومی",
                Value = "Economy"
                },
                new SelectListItem
                {
                Text = "بیزینس کلاس",
                Value = "Business"
                },
                new SelectListItem
                {
                Text = "فرست کلاس",
                Value = "First"
                }
            };
            ViewData["Classes"] = new SelectList(classes, "Value", "Text");
        }

        [HttpGet("{countryid}")]
        public IActionResult GetCities(int countryid)
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کنید",Value = ""}
            };
            list.AddRange(cityService.GetAllCityAsSelectList(countryid));
            return Json(new SelectList(list, "Value", "Text"));
        }

        [HttpGet("{cityid}")]
        public IActionResult GetAirports(int cityid)
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کنید",Value = ""}
            };
            list.AddRange(airportService.GetAllAirportAsSelectList(cityid));
            return Json(new SelectList(list, "Value", "Text"));
        }

        [HttpGet("{agancyid}")]
        public IActionResult GetAirplanes(int agancyid)
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کنید",Value = ""}
            };
            list.AddRange(airplaneService.GetAllAirplaneAsSelectList(agancyid));
            return Json(new SelectList(list, "Value", "Text"));
        }

    }
}
