using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = UserValidation.RequiredPhoneNumberError)]
        [RegularExpression(UserValidation.PhoneNumberRegex, ErrorMessage = UserValidation.InvalidPhoneNumberError)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = UserValidation.RequiredEmailError)]
        public string Email { get; set; }

        [Required(ErrorMessage = UserValidation.RequiredPasswordError)]
        [RegularExpression(UserValidation.PasswordRegex, ErrorMessage = UserValidation.InvalidPasswordError)]
        public string Password { get; set; }

        [Required(ErrorMessage = UserValidation.RequiredRePasswordError)]
        [Compare("Password", ErrorMessage = UserValidation.PasswordCompareError)]
        public string RePassword { get; set; }

        [Required(ErrorMessage = UserValidation.RequiredRulesError)]
        public bool Rules { get; set; }
    }
}
