using FlyWithUs.Hosted.Service.ApplicationService.Services.Users;
using FlyWithUs.Hosted.Service.ApplicationService.Services.World;
using FlyWithUs.Hosted.Service.DTOs.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly UserService userService;
        private readonly CountryService countryService;
        public UsersController()
        {
            userService = new UserService();
            countryService = new CountryService();
        }
        public IActionResult GetAllUser()
        {
            List<UserDTO> dtos = userService.GetAllUser();
            return View(dtos);
        }


        [HttpGet]
        public IActionResult AddUser()
        {
            var countries = countryService.GetAllCountryForAddUser();
            ViewData["Countries"] = new SelectList(countries, "Value", "Text");

            var genders = new List<SelectListItem>();
            SelectListItem item1 = new SelectListItem
            {
                Text = "مرد",
                Value = "مرد"
            };
            SelectListItem item2 = new SelectListItem
            {
                Text = "زن",
                Value = "زن"
            };
            genders.Add(item1);
            genders.Add(item2);
            ViewData["Genders"] = new SelectList(genders, "Value", "Text");
            return View();
        }

        [HttpPost]
        public IActionResult AddUser([FromForm] UserAddDTO dto)
        {
            if (ModelState.IsValid)
            {
                userService.AddUser(dto);
                return Redirect("/Admin/Users/GetAllUser");
            }
            else
            {
                return View(dto);
            }
        }
    }
}
