using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class ForgotPasswordDTO
    {
        [Required(ErrorMessage = UserValidation.RequiredPhoneNumberError)]
        [StringLength(11, ErrorMessage = UserValidation.LengthError)]
        [RegularExpression(UserValidation.PhoneNumberRegex, ErrorMessage = UserValidation.InvalidPhoneNumberError)]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = UserValidation.RequiredEmailError)]
        [StringLength(128, ErrorMessage = UserValidation.LengthError)]
        [EmailAddress(ErrorMessage = UserValidation.InvalidEmailError)]
        public string Email { get; set; }
    }
}
