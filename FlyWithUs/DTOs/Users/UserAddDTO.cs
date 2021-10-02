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
        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredInput)]
        [StringLength(11, ErrorMessage = CustomDTOValidation.Length)]
        [RegularExpression("09(1[0-9]|3[1-9])[0-9]{3}[0-9]{4}", ErrorMessage = CustomDTOValidation.InvalidInput)]
        public string PhoneNumber { get; set; }


        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredInput)]
        [StringLength(128, ErrorMessage = CustomDTOValidation.Length)]
        [EmailAddress(ErrorMessage = CustomDTOValidation.InvalidInput)]
        public string Email { get; set; }


        [Display(Name = "رمزعبور")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredInput)]
        [StringLength(128, ErrorMessage = CustomDTOValidation.Length)]
        public string Password { get; set; }


        [Display(Name = "تکرار رمزعبور")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredInput)]
        [StringLength(128, ErrorMessage = CustomDTOValidation.Length)]
        [Compare("Password", ErrorMessage = "رمز عبور و تکرار آن یکسان نیست")]
        public string RePassword { get; set; }


        [Display(Name = "ملیت")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredSelect)]
        public int NationalityId { get; set; }


        [Display(Name = "نام فارسی")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredInput)]
        [StringLength(128, ErrorMessage = CustomDTOValidation.Length)]
        [RegularExpression("^[آابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهی]+$", ErrorMessage = CustomDTOValidation.InvalidInput)]
        public string FirstNamePersian { get; set; }


        [Display(Name = "نام خانوادگی فارسی")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredInput)]
        [StringLength(128, ErrorMessage = CustomDTOValidation.Length)]
        [RegularExpression("^[آابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهی]+$", ErrorMessage = CustomDTOValidation.InvalidInput)]
        public string LastNamePersian { get; set; }


        [Display(Name = "نام انگلیسی")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredInput)]
        [StringLength(128, ErrorMessage = CustomDTOValidation.Length)]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = CustomDTOValidation.InvalidInput)]
        public string FirstNameEnglish { get; set; }


        [Display(Name = " نام خانوادگی انگلیسی")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredInput)]
        [StringLength(128, ErrorMessage = CustomDTOValidation.Length)]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = CustomDTOValidation.InvalidInput)]
        public string LastNameEnglish { get; set; }


        [Display(Name = "کدملی")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredInput)]
        [StringLength(32, ErrorMessage = CustomDTOValidation.Length)]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = CustomDTOValidation.InvalidInput)]
        public string NationalityCode { get; set; }


        [Display(Name = " تاریخ تولد")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredSelect)]
        public DateTime Birthdate { get; set; }


        [Display(Name = "جنسیت")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredSelect)]
        public string Gender { get; set; }


        [Display(Name = "شماره گذرنامه")]
        [StringLength(32, ErrorMessage = CustomDTOValidation.Length)]
        [RegularExpression("[A-Z|a-z][0-9]{8}$", ErrorMessage = CustomDTOValidation.InvalidInput)]
        public string PassportNumber { get; set; }



        public DateTime? PassportIssunaceDate { get; set; }


        public DateTime? PassportExpirationDate { get; set; }

    }
}
