using FlyWithUs.Hosted.Service.DTOs.Airports;
using FlyWithUs.Hosted.Service.DTOs.Cities;
using System.Collections.Generic;

namespace FlyWithUs.Hosted.Service.DTOs.Countries
{
    public class CountryDTO
    {
        public CountryDTO()
        {
            AirportDTOs = new List<AirportDTO>();
            CityDTOs = new List<CityDTO>();
        }

        public int Id { get; set; }

        public string PersianName { get; set; }

        public List<CityDTO> CityDTOs { get; set; }

        public List<AirportDTO> AirportDTOs { get; set; }
    }
}
