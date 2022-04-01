using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Airplanes
{
    public class AirplaneIdDTO
    {
        [Required]
        public int Id { get; set; }
    }
}
