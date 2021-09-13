﻿using FlyWithUs.Hosted.Service.Models.Airplanes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Airplanes
{
    interface IAirplaneRepository
    {
        int AddAirplane(Airplane airplane);

        int UpdateAirplane(Airplane airplane);

        int DeleteAirplane(int airplaneid);

        Airplane GetAirplaneById(int airplaneid);

        List<Airplane> GetAllAirplane();

        List<Airplane> GetAllAirplaneByAgancy(int agancyid);

        int Save();
    }
}
