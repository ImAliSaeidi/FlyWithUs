using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Agancies
{
    public class AgancyUpdateDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = AgancyValidation.RequiredError)]
        [StringLength(128, ErrorMessage = AgancyValidation.LengthError)]
        public string Name { get; set; }
    }
}
