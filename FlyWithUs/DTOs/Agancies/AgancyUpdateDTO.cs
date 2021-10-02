using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Agancies
{
    public class AgancyUpdateDTO
    {
        public int Id { get; set; }

        [Display(Name = "نام آژانس هواپیمایی")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredInput)]
        [StringLength(128, ErrorMessage = CustomDTOValidation.Length)]
        public string Name { get; set; }
    }
}
