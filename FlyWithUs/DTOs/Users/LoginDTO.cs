using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class LoginDTO
    {
        [Required(ErrorMessage = UserValidation.RequiredPhoneNumberError)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = UserValidation.RequiredPasswordError)]
        public string Password { get; set; }
    }
}
