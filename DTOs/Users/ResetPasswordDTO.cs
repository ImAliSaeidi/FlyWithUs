using System.ComponentModel.DataAnnotations;
namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class ResetPasswordDTO
    {
        [Required]
        public string ActiveCode { get; set; }


        [Required(ErrorMessage = UserValidation.RequiredEmailError)]
        public string Email { get; set; }


        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [Required(ErrorMessage = UserValidation.RequiredNewPasswordError)]
        [RegularExpression(UserValidation.PasswordRegex, ErrorMessage = UserValidation.InvalidPasswordError)]
        public string NewPassword { get; set; }


        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [Compare("NewPassword", ErrorMessage = UserValidation.PasswordCompareError)]
        [Required(ErrorMessage = UserValidation.RequiredReNewPasswordError)]
        [RegularExpression(UserValidation.PasswordRegex, ErrorMessage = UserValidation.InvalidPasswordError)]
        public string ReNewPassword { get; set; }
    }
}
