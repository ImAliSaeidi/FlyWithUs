using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Countries
{
    public class CountryUpdateDTO
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "لطفا نام کشور را وارد کنید")]
        [StringLength(128, ErrorMessage = "طول مقدار ورودی بیش از حد مجاز استس")]
        public string NiceName { get; set; }

        [MaxLength(6, ErrorMessage = "لطفا کد کشور را وارد کنید")]
        public short? NumCode { get; set; }


        [MaxLength(5, ErrorMessage = "لطفا کد تلفن کشور را وارد کنید")]
        public short? PhoneCode { get; set; }
    }
}
