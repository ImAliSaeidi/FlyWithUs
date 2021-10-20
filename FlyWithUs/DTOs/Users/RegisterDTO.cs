using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = UserValidation.RequiredPhoneNumberError)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = UserValidation.RequiredEmailError)]
        public string Email { get; set; }

        [Required(ErrorMessage = UserValidation.RequiredPasswordError)]
        public string Password { get; set; }

        [Required(ErrorMessage = UserValidation.RequiredRePasswordError)]
        public string RePassword { get; set; }

        [Required(ErrorMessage = UserValidation.RequiredRulesError)]
        public bool Rules { get; set; }
    }
}
