using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Cities
{
    public class CityIdDTO
    {
        [Required]
        public int Id { get; set; }
    }
}
