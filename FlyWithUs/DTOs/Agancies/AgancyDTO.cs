using FlyWithUs.Hosted.Service.DTOs.Airplanes;
using System;
using System.Collections.Generic;

namespace FlyWithUs.Hosted.Service.DTOs.Agancies
{
    public class AgancyDTO
    {
        public AgancyDTO()
        {
            AirplaneDTOs = new List<AirplaneDTO>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public List<AirplaneDTO> AirplaneDTOs { get; set; }
    }
}
