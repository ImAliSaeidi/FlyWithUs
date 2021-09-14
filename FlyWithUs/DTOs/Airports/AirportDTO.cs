using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Airports
{
    public class AirportDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string EnglishName { get; set; }

        public string Code { get; set; }

        public string CityName { get; set; }
    }
}
