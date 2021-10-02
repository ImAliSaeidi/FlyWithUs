using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Countries
{
    public class CountryUpdateDTO
    {
        public int Id { get; set; }


        [Display(Name = "نام کشور")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredInput)]
        [StringLength(128, ErrorMessage = CustomDTOValidation.Length)]
        public string PersianName { get; set; }

        [Display(Name = "نام کشور")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredInput)]
        [StringLength(128, ErrorMessage = CustomDTOValidation.Length)]
        public string EnglishName { get; set; }


        [Display(Name = "کد تلفن")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredInput)]
        public short PhoneCode { get; set; }

    }
}
