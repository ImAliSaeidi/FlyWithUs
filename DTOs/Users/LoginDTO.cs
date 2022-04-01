using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class LoginDTO
    {
        [Required(ErrorMessage = UserValidation.RequiredPhoneNumberError)]
        [RegularExpression(UserValidation.PhoneNumberRegex, ErrorMessage = UserValidation.InvalidPhoneNumberError)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = UserValidation.RequiredPasswordError)]
        [RegularExpression(UserValidation.PasswordRegex, ErrorMessage = UserValidation.InvalidPasswordError)]
        public string Password { get; set; }
    }
}
