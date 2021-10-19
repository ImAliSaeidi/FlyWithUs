using System;

namespace FlyWithUs.Hosted.Service.DTOs.Travels
{
    public class TravelDTO
    {
        public int Id { get; set; }

        public int MaxCapacity { get; set; }

        public int SoldTicket { get; set; }

        public int Price { get; set; }

        public string OriginCityName { get; set; }

        public string DestinationCityName { get; set; }

        public string OriginAirportName { get; set; }

        public string DestinationAirportName { get; set; }

        public string AgancyName { get; set; }

        public string AirplaneName { get; set; }

        public DateTime MovingTime { get; set; }

        public DateTime ArrivingTime { get; set; }

        public DateTime MovingDate { get; set; }

        public DateTime ArrivingDate { get; set; }

        public string Type { get; set; }

        public string Class { get; set; }

    }
}
