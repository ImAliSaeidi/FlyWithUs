using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class ChangePasswordDTO
    {
        public string Id { get; set; }

        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [Required(ErrorMessage = UserValidation.RequiredCurrentPasswordError)]
        [RegularExpression(UserValidation.PasswordRegex, ErrorMessage = UserValidation.InvalidPasswordError)]
        public string CurrentPassword { get; set; }



        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [Required(ErrorMessage = UserValidation.RequiredNewPasswordError)]
        [RegularExpression(UserValidation.PasswordRegex, ErrorMessage = UserValidation.InvalidPasswordError)]
        public string NewPassword { get; set; }


        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [Compare("NewPassword", ErrorMessage = UserValidation.PasswordCompareError)]
        [Required(ErrorMessage = UserValidation.RequiredReNewPasswordError)]
        public string ReNewPassword { get; set; }
    }
}
