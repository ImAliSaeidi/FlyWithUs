using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Cities
{
    public class CityUpdateDTO
    {
        public int Id { get; set; }


        [Display(Name = "نام شهر")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredInput)]
        [StringLength(128, ErrorMessage = CustomDTOValidation.Length)]
        public string Name { get; set; }


        [Display(Name = "کشور")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredSelect)]
        public int CountryId { get; set; }

    }
}
