using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Airplanes
{
    public class AirplaneDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public int MaxCapacity { get; set; }

        public string AgancyName { get; set; }
    }
}
