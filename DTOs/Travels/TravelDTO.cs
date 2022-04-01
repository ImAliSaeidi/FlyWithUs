using System;

namespace FlyWithUs.Hosted.Service.DTOs.Travels
{
    public class TravelDTO
    {
        public int Id { get; set; }

        public int MaxCapacity { get; set; }

        public int SoldTicket { get; set; }

        public int Price { get; set; }

        public int OriginCountryId { get; set; }

        public int DestinationCountryId { get; set; }

        public int OriginCityId { get; set; }
                     
        public int DestinationCityId { get; set; }
        
        public int AgancyId { get; set; }
        
        public int AirplaneId { get; set; }
        
        public int OriginAirportId { get; set; }
        
        public int DestinationAirportId { get; set; }

        public string OriginCityName { get; set; }

        public string DestinationCityName { get; set; }

        public string OriginAirportName { get; set; }

        public string DestinationAirportName { get; set; }

        public string AgancyName { get; set; }

        public string AirplaneName { get; set; }

        public string MovingTime { get; set; }

        public string ArrivingTime { get; set; }

        public string MovingDate { get; set; }

        public string ArrivingDate { get; set; }

        public string Type { get; set; }

        public string Class { get; set; }

    }
}
