using FlyWithUs.Hosted.Service.DTOs.Airports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Cities
{
    public class CityDTO
    {
        public CityDTO()
        {
            AirportDTOs = new List<AirportDTO>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public List<AirportDTO> AirportDTOs { get; set; }
    }
}
