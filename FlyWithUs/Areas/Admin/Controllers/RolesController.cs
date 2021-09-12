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
                if (roleService.IsRoleExist(dto.Name,null) == true)
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

        public IActionResult DeleteRole(int id)
        {
            bool result = roleService.DeleteRole(id);
            if (result == true)
            {
                return Redirect("/Admin/Roles/GetAllRole");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult EditRole(int id)
        {
            RoleUpdateDTO dto = roleService.GetRoleForUpdate(id);
            return View(dto);
        }
        [HttpPost]
        public IActionResult EditRole([FromForm] RoleUpdateDTO dto)
        {
            if (ModelState.IsValid)
            {
                if (roleService.IsRoleExist(dto.Name,dto.Id) == true)
                {
                    ModelState.AddModelError("Name", "نام وارد شده معتبر نیست");
                    return View(dto);
                }
                else
                {
                    roleService.UpdateRole(dto);
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
