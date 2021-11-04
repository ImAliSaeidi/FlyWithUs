using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Users
{
    public class UserIdDTO
    {
        [Required]
        public string Id { get; set; }
    }
}
