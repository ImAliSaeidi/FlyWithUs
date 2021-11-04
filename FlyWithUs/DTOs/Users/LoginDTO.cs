using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class LoginDTO
    {
        [Required(ErrorMessage = UserValidation.RequiredPhoneNumberError)]
        [RegularExpression("09(1[0-9]|3[1-9])[0-9]{3}[0-9]{4}", ErrorMessage = UserValidation.InvalidPhoneNumberError)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = UserValidation.RequiredPasswordError)]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z]|[A-Z]).{6,128}$", ErrorMessage = UserValidation.InvalidPasswordError)]
        public string Password { get; set; }
    }
}
