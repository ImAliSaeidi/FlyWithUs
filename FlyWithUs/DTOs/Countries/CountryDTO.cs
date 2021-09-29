using FlyWithUs.Hosted.Service.DTOs.Airports;
using FlyWithUs.Hosted.Service.DTOs.Cities;
using FlyWithUs.Hosted.Service.Models.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public short PhoneCode { get; set; }

        public List<CityDTO> CityDTOs { get; set; }

        public List<AirportDTO> AirportDTOs { get; set; }
    }
}
