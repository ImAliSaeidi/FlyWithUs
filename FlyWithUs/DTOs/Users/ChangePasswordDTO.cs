using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class ChangePasswordDTO
    {
        public string Id { get; set; }

        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [Required(ErrorMessage = UserValidation.RequiredCurrentPasswordError)]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z]|[A-Z]).{6,128}$", ErrorMessage = UserValidation.InvalidPasswordError)]
        public string CurrentPassword { get; set; }



        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [Required(ErrorMessage = UserValidation.RequiredNewPasswordError)]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z]|[A-Z]).{6,128}$", ErrorMessage = UserValidation.InvalidPasswordError)]
        public string NewPassword { get; set; }


        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [Compare("NewPassword", ErrorMessage = UserValidation.PasswordCompareError)]
        [Required(ErrorMessage = UserValidation.RequiredReNewPasswordError)]
        public string ReNewPassword { get; set; }
    }
}
