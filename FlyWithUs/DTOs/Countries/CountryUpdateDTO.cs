using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Countries
{
    public class CountryUpdateDTO: CountryAddDTO
    {
        public int Id { get; set; }

    }
}
