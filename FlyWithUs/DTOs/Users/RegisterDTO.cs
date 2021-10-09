using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.User
{
    public class RegisterDTO
    {
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string RePassword { get; set; }

        [Required]
        public bool Rules { get; set; }
    }
}
