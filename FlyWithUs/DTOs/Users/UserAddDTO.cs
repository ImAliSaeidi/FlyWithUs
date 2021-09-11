using FlyWithUs.Hosted.Service.DTOs.Countries;
using FlyWithUs.Hosted.Service.Models.World;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class UserAddDTO
    {
        [Required(ErrorMessage = "لطفا شماره موبایل را وارد کنید")]
        [StringLength(11, ErrorMessage = "طول مقدار ورودی مجاز نیست")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "لطفا ایمیل را وارد کنید")]
        [StringLength(128, ErrorMessage = "طول مقدار ورودی مجاز نیست")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نیست")]
        public string Email { get; set; }


        [Required(ErrorMessage = "لطفا رمزعبور را وارد کنید")]
        [StringLength(128, ErrorMessage = "طول مقدار ورودی مجاز نیست")]
        public string Password { get; set; }


        [Required(ErrorMessage = "لطفا تکرار رمزعبور را وارد کنید")]
        [StringLength(128, ErrorMessage = "طول مقدار ورودی مجاز نیست")]
        [Compare("Password", ErrorMessage = "رمز عبور و تکرار آن یکسان نیست")]
        public string RePassword { get; set; }



        [Required(ErrorMessage = "لطفا ملیت را انتخاب کنید")]
        public int NtionalityId { get; set; }


        [Required(ErrorMessage = "لطفا نام فارسی را وارد کنید")]
        [StringLength(128, ErrorMessage = "طول مقدار ورودی مجاز نیست")]
        public string FirstNamePersian { get; set; }


        [Required(ErrorMessage = "لطفا نام خانوادگی فارسی را وارد کنید")]
        [StringLength(128, ErrorMessage = "طول مقدار ورودی مجاز نیست")]
        public string LastNamePersian { get; set; }


        [Required(ErrorMessage = "لطفا نام انگلیسی را وارد کنید")]
        [StringLength(128, ErrorMessage = "طول مقدار ورودی مجاز نیست")]
        public string FirstNameEnglish { get; set; }


        [Required(ErrorMessage = "لطفا نام خانوادگی انگلیسی را وارد کنید")]
        [StringLength(128, ErrorMessage = "طول مقدار ورودی مجاز نیست")]
        public string LastNameEnglish { get; set; }


        [Required(ErrorMessage = "لطفا کدملی را وارد کنید")]
        [StringLength(32, ErrorMessage = "طول مقدار ورودی مجاز نیست")]
        public string NationalityCode { get; set; }


        [Required(ErrorMessage = "لطفا تاریخ تولد را انتخاب کنید")]
        public DateTime BirthdateAD { get; set; }


        [Required(ErrorMessage = "لطفا جنسیت را انتخاب کنید")]
        public string Gender { get; set; }

    }
}
