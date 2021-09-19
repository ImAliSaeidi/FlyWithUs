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

        public TravelsController(ITravelService travelService, ICityService cityService, ICountryService countryService, IAirportService airportService)
        {
            this.travelService = travelService;
            this.cityService = cityService;
            this.countryService = countryService;
            this.airportService = airportService;
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


        #region Fill View Data Method
        private void FillViewData()
        {
            var countries = countryService.GetAllCountryAsSelectList();
            ViewData["Countries"] = new SelectList(countries, "Value", "Text");

            var cities = cityService.GetAllCityAsSelectList();
            ViewData["Cities"] = new SelectList(cities, "Value", "Text");

            var airports = airportService.GetAllAirportAsSelectList();
            ViewData["Airports"] = new SelectList(airports, "Value", "Text");
        }
        #endregion]
    }
}
