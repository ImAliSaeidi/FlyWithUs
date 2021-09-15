using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Travels
{
    public class TravelAddDTO
    {
        [Required(ErrorMessage = "لطفا شهر مبدا را انتخاب کنید")]
        public int OriginCityId { get; set; }


        [Required(ErrorMessage = "لطفا شهر مقصد را انتخاب کنید")]
        public int DestinationCityId { get; set; }
    }
}
