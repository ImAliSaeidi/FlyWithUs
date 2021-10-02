using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Airports
{
    public class AirportAddDTO
    {
        [Display(Name = "نام فرودگاه")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredInput)]
        [StringLength(128, ErrorMessage = CustomDTOValidation.Length)]
        public string Name { get; set; }


        [Display(Name = "نام  انگلیسی فرودگاه")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredInput)]
        [StringLength(128, ErrorMessage = CustomDTOValidation.Length)]
        public string EnglishName { get; set; }


        [Display(Name = "شهر")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredSelect)]
        public int CityId { get; set; }
    }
}
