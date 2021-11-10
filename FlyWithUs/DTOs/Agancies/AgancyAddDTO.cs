using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Agancies
{
    public class AgancyAddDTO
    {

        [Required(ErrorMessage = AgancyValidation.RequiredNameError)]
        [StringLength(128, ErrorMessage = AgancyValidation.LengthError)]
        [RegularExpression(AgancyValidation.NameRegex, ErrorMessage = AgancyValidation.InvalidNameError)]
        public string Name { get; set; }
    }
}
