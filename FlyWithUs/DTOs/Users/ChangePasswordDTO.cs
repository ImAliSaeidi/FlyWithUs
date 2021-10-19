using System.ComponentModel.DataAnnotations;

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
