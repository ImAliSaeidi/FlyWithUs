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
            FillViewData();
            return View();
        }

        [HttpPost]
        public IActionResult AddUser([FromForm] UserAddDTO dto)
        {
            if (ModelState.IsValid)
            {
                if (userService.IsPhoneNumberExist(dto.PhoneNumber) == true)
                {
                    ModelState.AddModelError("PhoneNumber", "شماره تلفن وارد شده معتبر نیست");
                    FillViewData();
                    return View(dto);
                }
                else if (userService.IsEmailExist(dto.Email) == true)
                {
                    ModelState.AddModelError("Email", "ایمیل وارد شده معتبر نیست");
                    FillViewData();
                    return View(dto);
                }
                else
                {
                    if (userService.AddUser(dto) == true)
                    {
                        return Redirect("/Admin/Users/GetAllUser");
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            else
            {
                FillViewData();
                return View(dto);
            }
        }

        private void FillViewData()
        {
            var countries = countryService.GetAllCountryForAddUser();
            ViewData["Countries"] = new SelectList(countries, "Value", "Text");

            var genders = new List<SelectListItem>() {
                new SelectListItem
                {
                Text = "مرد",
                Value = "مرد"
                },
                new SelectListItem
                {
                Text = "زن",
                Value = "زن"
                }
            };
            ViewData["Genders"] = new SelectList(genders, "Value", "Text");
        }

        public IActionResult GetUser(int id)
        {
            var user = userService.GetUserById(id);
            return View(user);
        }


        public IActionResult DeleteUser(int id)
        {
            var result = userService.DeleteUser(id);
            if (result == true)
            {
                return Redirect("/Admin/Users/GetAllUser");
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var userupdatedto = userService.GetUserForUpdate(id);
            FillViewData();
            return View(userupdatedto);
        }

        [HttpPost]
        public IActionResult EditUser([FromForm] UserUpdateDTO dto)
        {
            if (ModelState.IsValid)
            {
                userService.UpdateUser(dto);
                return Redirect("/Admin/Users/GetAllUser");
            }
            else
            {
                FillViewData();
                return View(dto);
            }
        }
    }
}
