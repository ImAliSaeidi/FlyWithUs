using FlyWithUs.Hosted.Service.ApplicationService.IServices.Users;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly ICountryService countryService;



        public UsersController(IUserService userService, ICountryService countryService)
        {
            this.userService = userService;
            this.countryService = countryService;
        }


        [HttpGet("{skip=0}/{take=10}")]
        public IActionResult GetAllUser([Required] int skip = 0, int take = 10)
        {
            GridResultDTO<UserDTO> dto = userService.GetAllUser(skip, take);
            return View(dto);
        }

        [HttpGet("{userid}")]
        public IActionResult GetUser(int userid)
        {
            var user = userService.GetUserById(userid);
            return View(user);
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

        [HttpGet("{userid}")]
        public IActionResult DeleteUser(int userid)
        {
            var result = userService.DeleteUser(userid);
            if (result == true)
            {
                return Redirect("/Admin/Users/GetAllUser");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{userid}")]
        public IActionResult EditUser(int userid)
        {
            var userupdatedto = userService.GetUserForUpdate(userid);
            FillViewData();
            return View(userupdatedto);
        }

        [HttpPost]
        public IActionResult EditUser([FromForm] UserUpdateDTO dto)
        {
            if (ModelState.IsValid)
            {
                if (userService.IsPhoneNumberExist(dto.PhoneNumber, dto.Id) == true)
                {
                    ModelState.AddModelError("PhoneNumber", "شماره تلفن وارد شده معتبر نیست");
                    FillViewData();
                    return View(dto);
                }
                else if (userService.IsEmailExist(dto.Email, dto.Id) == true)
                {
                    ModelState.AddModelError("Email", "ایمیل وارد شده معتبر نیست");
                    FillViewData();
                    return View(dto);
                }
                else
                {
                    userService.UpdateUser(dto);
                    return Redirect("/Admin/Users/GetAllUser");
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
            var countries = countryService.GetAllCountryAsSelectList();
            ViewData["Countries"] = new SelectList(countries, "Value", "Text");

            var genders = new List<SelectListItem>() {
                new SelectListItem
                {
                Text = "مرد",
                Value = "Male"
                },
                new SelectListItem
                {
                Text = "زن",
                Value = "Female"
                }
            };
            ViewData["Genders"] = new SelectList(genders, "Value", "Text");
        }
    }
}
