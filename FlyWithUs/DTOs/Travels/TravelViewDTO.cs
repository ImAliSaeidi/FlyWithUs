using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Travels
{
    public class TravelViewDTO
    {
        public int Id { get; set; }

        public string TravelCode { get; set; }

        public string Price { get; set; }

        public string Type { get; set; }

        public string Class { get; set; }

        public string MovingDate { get; set; }

        public string MovingTime { get; set; }

        public string ArrivingDate { get; set; }

        public string ArrivingTime { get; set; }

        public string AgancyName { get; set; }

        public string AirplaneName { get; set; }

        public string OriginAirportName { get; set; }

        public string DestinationAirportName { get; set; }

        public string OriginCityName { get; set; }

        public string DestinationCityName { get; set; }

        public string OriginCountryName { get; set; }

        public string DestinationCountryName { get; set; }

        public bool IsDeleted { get; set; }
    }
}
