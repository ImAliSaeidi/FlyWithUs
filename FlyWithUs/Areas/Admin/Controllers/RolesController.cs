using FlyWithUs.Hosted.Service.ApplicationService.Services.Users;
using FlyWithUs.Hosted.Service.DTOs.Roles;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly RoleService roleService;
        public RolesController()
        {
            roleService = new RoleService();
        }
        public IActionResult GetAllRole()
        {
            List<RoleDTO> dtos = roleService.GetAllRole();
            return View(dtos);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole([FromForm] RoleAddDTO dto)
        {
            if (ModelState.IsValid)
            {
                if (roleService.IsRoleExist(dto.Name) == true)
                {
                    ModelState.AddModelError("Name", "نام نقش معتبر نیست");
                    return View(dto);
                }
                else
                {
                    roleService.AddRole(dto);
                    return Redirect("/Admin/Roles/GetAllRole");
                }
            }
            else
            {
                return View(dto);
            }
        }
    }
}
