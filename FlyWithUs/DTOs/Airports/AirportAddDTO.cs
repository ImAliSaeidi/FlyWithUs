using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Airports
{
    public class AirportAddDTO
    {
        [Required(ErrorMessage ="لطفا نام فرودگاه را وارد کنید")]
        [StringLength(128,ErrorMessage ="طول مقدار ورودی بیش از حد مجاز است")]
        public string Name { get; set; }


        [Required(ErrorMessage = "لطفا نام فرودگاه را وارد کنید")]
        [StringLength(128, ErrorMessage = "طول مقدار ورودی بیش از حد مجاز است")]
        public string EnglishName { get; set; }


        [Required(ErrorMessage = "لطفا شهر را انتخاب کنید")]
        public int CityId { get; set; }
    }
}
