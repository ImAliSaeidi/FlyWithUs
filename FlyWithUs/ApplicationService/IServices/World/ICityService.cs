﻿using FlyWithUs.Hosted.Service.DTOs.Cities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.World
{
    public interface ICityService
    {
        bool AddCity(CityAddDTO dto);

        bool UpdateCity(CityUpdateDTO dto);

        bool DeleteCity(int cityid);

        List<CityDTO> GetAllCity();

        CityUpdateDTO GetCityForUpdate(int cityid);

        bool IsCityExist(string name, int countryid, int? cityid);

        List<SelectListItem> GetAllCityAsSelectList();

        CityDTO GetCityById(int cityid);
    }
}
