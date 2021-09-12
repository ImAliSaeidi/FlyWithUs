using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class UserUpdateDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "لطفا شماره موبایل را وارد کنید")]
        [StringLength(11, ErrorMessage = "طول مقدار ورودی مجاز نیست")]
        [RegularExpression("09(1[0-9]|3[1-9])[0-9]{3}[0-9]{4}", ErrorMessage = "شماره وارد شده معتبر نیست")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "لطفا ایمیل را وارد کنید")]
        [StringLength(128, ErrorMessage = "طول مقدار ورودی مجاز نیست")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نیست")]
        public string Email { get; set; }


        [StringLength(128, ErrorMessage = "طول مقدار ورودی مجاز نیست")]
        public string Password { get; set; }


        [StringLength(128, ErrorMessage = "طول مقدار ورودی مجاز نیست")]
        [Compare("Password", ErrorMessage = "رمز عبور و تکرار آن یکسان نیست")]
        public string RePassword { get; set; }



        [Required(ErrorMessage = "لطفا ملیت را انتخاب کنید")]
        public int NationalityId { get; set; }


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
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "کدملی وارد شده معتبر نیست")]
        public string NationalityCode { get; set; }


        [Required(ErrorMessage = "لطفا تاریخ تولد را انتخاب کنید")]
        public DateTime BirthdateAD { get; set; }


        [Required(ErrorMessage = "لطفا جنسیت را انتخاب کنید")]
        public string Gender { get; set; }


        [StringLength(32, ErrorMessage = "طول مقدار ورودی مجاز نیست")]
        [RegularExpression("[A-Z|a-z][0-9]{8}$", ErrorMessage = "شماره وارد شده معتبر نیست")]
        public string PassportNumber { get; set; }


        public DateTime? PassportIssunaceDate { get; set; }


        public DateTime? PassportExpirationDate { get; set; }
    }
}
