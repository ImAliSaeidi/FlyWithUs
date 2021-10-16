using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class ChangePasswordDTO
    {
        public string Id { get; set; }

        [Display(Name = "رمزعبور فعلی")]
        [StringLength(128, ErrorMessage = CustomDTOValidation.Length)]
        [Required(ErrorMessage = CustomDTOValidation.RequiredInput)]
        public string CurrentPassword { get; set; }

        [Display(Name = "رمزعبور جدید")]
        [StringLength(128, ErrorMessage = CustomDTOValidation.Length)]
        [Required(ErrorMessage = CustomDTOValidation.RequiredInput)]
        public string NewPassword { get; set; }


        [Display(Name = "تکرار رمزعبور جدید")]
        [StringLength(128, ErrorMessage = CustomDTOValidation.Length)]
        [Compare("NewPassword", ErrorMessage = "رمز عبور جدید و تکرار آن یکسان نیست")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredInput)]
        public string ReNewPassword { get; set; }
    }
}
