using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Models.Travels
{
    public class TravelView
    {
        [Key]
        public int Id { get; set; }

        public int Price { get; set; }

        public int MaxCapacity { get; set; }

        public string Type { get; set; }

        public string Class { get; set; }

        public DateTime MovingDate { get; set; }

        public DateTime MovingTime { get; set; }

        public DateTime ArrivingDate { get; set; }

        public DateTime ArrivingTime { get; set; }

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
