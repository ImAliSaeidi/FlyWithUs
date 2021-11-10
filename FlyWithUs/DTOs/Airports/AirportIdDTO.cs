using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Airports
{
    public class AirportIdDTO
    {
        [Required]
        public int Id { get; set; }
    }
}
