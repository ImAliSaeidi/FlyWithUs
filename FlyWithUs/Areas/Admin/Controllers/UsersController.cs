using FlyWithUs.Hosted.Service.ApplicationService.IServices.Users;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using FlyWithUs.Hosted.Service.ApplicationService.Services.Users;
using FlyWithUs.Hosted.Service.ApplicationService.Services.World;
using FlyWithUs.Hosted.Service.DTOs.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FlyWithUs.Hosted.Service.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly ICountryService countryService;

        public UsersController(IUserService userService, ICountryService countryService)
        {
            this.userService = userService;
            this.countryService = countryService;
        }


        #region Get All User
        public IActionResult GetAllUser()
        {
            List<UserDTO> dtos = userService.GetAllUser();
            return View(dtos);
        }
        #endregion


        #region Add User
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
                if (userService.IsPhoneNumberExist(dto.PhoneNumber, null) == true)
                {
                    ModelState.AddModelError("PhoneNumber", "شماره تلفن وارد شده معتبر نیست");
                    FillViewData();
                    return View(dto);
                }
                else if (userService.IsEmailExist(dto.Email, null) == true)
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
        #endregion


        #region Fill View Data Methods
        private void FillViewData()
        {
            var countries = countryService.GetAllCountryAsSelectList();
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
        #endregion


        #region Get User
        public IActionResult GetUser(int id)
        {
            var user = userService.GetUserById(id);
            return View(user);
        }
        #endregion


        #region Delete User
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
        #endregion


        #region Edit User
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
        #endregion
    }
}
