using FlyWithUs.Hosted.Service.Models.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Countries
{
    public class CountryDTO
    {
        public int Id { get; set; }

        public string NiceName { get; set; }

        public short NumCode { get; set; }

        public short PhoneCode { get; set; }

        public List<City> Cities { get; set; }
    }
}
