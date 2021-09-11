using FlyWithUs.Hosted.Service.ApplicationService.Services;
using FlyWithUs.Hosted.Service.DTOs.Users;
using Microsoft.AspNetCore.Mvc;
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
        public UsersController()
        {
            userService = new UserService();
        }
        public IActionResult GetAllUser()
        {
            List<UserDTO> dtos = userService.GetAllUser();
            return View(dtos);
        }


        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser([FromForm] UserAddDTO dto)
        {
            return View();
        }


    }
}
