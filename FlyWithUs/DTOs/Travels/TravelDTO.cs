using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Travels
{
    public class TravelDTO
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public int MaxCapacity { get; set; }

        public string OriginCityName { get; set; }

        public string DestinationCityName { get; set; }

    }
}
