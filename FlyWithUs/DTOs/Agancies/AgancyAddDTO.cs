using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Agancies
{
    public class AgancyAddDTO
    {

        [Required(ErrorMessage = AgancyValidation.RequiredNameError)]
        [StringLength(128, ErrorMessage = AgancyValidation.LengthError)]
        public string Name { get; set; }
    }
}
