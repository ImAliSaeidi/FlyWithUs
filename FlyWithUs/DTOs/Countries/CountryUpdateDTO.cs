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
        [StringLength(128, ErrorMessage = "طول مقدار ورودی بیش از حد مجاز است")]
        public string NiceName { get; set; }

        [Required(ErrorMessage = "لطفا کد کشور را وارد کنید")]
        [MaxLength(6, ErrorMessage = "طول مقدار ورودی بیش از حد مجاز است")]
        public short NumCode { get; set; }


        [Required(ErrorMessage = "لطفا کد تلفن کشور را وارد کنید")]
        [MaxLength(5, ErrorMessage = "طول مقدار ورودی بیش از حد مجاز است")]
        public short PhoneCode { get; set; }
    }
}
