using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Cities
{
    public class CityAddDTO
    {
        [Required(ErrorMessage = "لطفا نام شهر را وارد کنید")]
        [StringLength(128, ErrorMessage = "طول مقدار ورودی بیش از حد  مجاز است")]
        public string Name { get; set; }


        [Required(ErrorMessage = "لطفا کشور را انتخاب کنید")]
        public int CountryId { get; set; }
    }
}
