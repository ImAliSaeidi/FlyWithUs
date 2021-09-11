using FlyWithUs.Hosted.Service.DTOs.Countries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.World
{
    interface ICountryService
    {
        List<SelectListItem> GetAllCountryForAddUser();
    }
}
