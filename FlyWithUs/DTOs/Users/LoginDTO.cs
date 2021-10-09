using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.User
{
    public class LoginDTO
    {
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
