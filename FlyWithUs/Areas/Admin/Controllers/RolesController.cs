using FlyWithUs.Hosted.Service.ApplicationService.IServices.Users;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Roles;
using FlyWithUs.Hosted.Service.Filter;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]")]
    public class RolesController : Controller
    {
        private readonly IRoleService roleService;

        public RolesController(IRoleService roleService)
        {
            this.roleService = roleService;
        }



        [HttpGet("{skip=0}/{take=10}")]
        public IActionResult GetAllRole([Required] int skip = 0, [Required] int take = 10)
        {
            GridResultDTO<RoleDTO> dto = roleService.GetAllRole(skip, take);
            return View(dto);
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

        [HttpGet("{roleid}")]
        public IActionResult DeleteRole(int roleid)
        {
            bool result = roleService.DeleteRole(roleid);
            if (result == true)
            {
                return Redirect("/Admin/Roles/GetAllRole");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{roleid}")]
        public IActionResult EditRole(int roleid)
        {
            RoleUpdateDTO dto = roleService.GetRoleForUpdate(roleid);
            return View(dto);
        }

        [HttpPost]
        public IActionResult EditRole([FromForm] RoleUpdateDTO dto)
        {
            if (ModelState.IsValid)
            {
                if (roleService.IsRoleExist(dto.Name, dto.Id) == true)
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
