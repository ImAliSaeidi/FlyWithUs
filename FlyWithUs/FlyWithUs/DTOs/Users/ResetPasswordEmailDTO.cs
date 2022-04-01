using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class ResetPasswordEmailDTO
    {
        public string FullNamePersian { get; set; }


        public string ActiveCode { get; set; }


        [Required(ErrorMessage = UserValidation.RequiredEmailError)]
        [EmailAddress(ErrorMessage = UserValidation.InvalidEmailError)]
        public string Email { get; set; }

        public string RedirectUrl { get; set; }
    }
}
