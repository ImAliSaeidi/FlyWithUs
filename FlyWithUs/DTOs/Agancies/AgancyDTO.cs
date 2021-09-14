﻿using FlyWithUs.Hosted.Service.DTOs.Airplanes;
using FlyWithUs.Hosted.Service.Models.Airplanes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Agancies
{
    public class AgancyDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CreateDate { get; set; }

        public List<AirplaneDTO> AirplaneDTOs { get; set; }
    }
}
