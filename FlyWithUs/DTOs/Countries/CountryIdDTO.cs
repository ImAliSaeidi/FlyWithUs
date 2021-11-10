using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Countries
{
    public class CountryIdDTO
    {
        [Required]
        public int Id { get; set; }
    }
}
