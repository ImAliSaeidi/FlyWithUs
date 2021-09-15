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

        public int SaledTicket { get; set; }

        public int Price { get; set; }

        public string OriginCityName { get; set; }

        public string DestinationCityName { get; set; }

        public string OriginAirportName { get; set; }

        public string DestinationAirportName { get; set; }

        public string MovingTime { get; set; }

        public string ArrivingTime { get; set; }

        public string MovingDate { get; set; }

        public string ArrivingDate { get; set; }

        public string Type { get; set; }

        public string Class { get; set; }

    }
}
