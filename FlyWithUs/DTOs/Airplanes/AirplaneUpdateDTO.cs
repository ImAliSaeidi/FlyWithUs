using FlyWithUs.Hosted.Service.Models.Airplanes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Airplanes
{
    public class AirplaneUpdateDTO : AirplaneAddDTO
    {
        public int Id { get; set; }

    }
}
