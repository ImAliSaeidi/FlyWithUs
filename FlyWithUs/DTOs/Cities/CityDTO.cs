using FlyWithUs.Hosted.Service.DTOs.Airports;
using FlyWithUs.Hosted.Service.Models;
using System.Collections.Generic;

namespace FlyWithUs.Hosted.Service.DTOs.Cities
{
    public class CityDTO
    {
        public CityDTO()
        {
            AirportDTOs = new List<AirportDTO>();
        }

        public int Id { get; set; }

        public string PersianName { get; set; }

        public string EnglishName { get; set; }

        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public List<AirportDTO> AirportDTOs { get; set; }
    }
}
