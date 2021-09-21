﻿using FlyWithUs.Hosted.Service.DTOs.Airplanes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.Airplanes
{
    public interface IAirplaneService
    {
        bool AddAirplane(AirplaneAddDTO dto);

        bool UpdateAirplane(AirplaneUpdateDTO dto);

        bool DeleteAirplane(int airplaneid);

        List<AirplaneDTO> GetAllAirplane();

        AirplaneUpdateDTO GetAirplaneForUpdate(int airplaneid);

        bool IsAirplaneExist(string name, string brand, int maxcapacity, int agancyid, int? airplaneid);

        List<SelectListItem> GetAllAirplaneAsSelectList(int agancyid);

    }
}
