using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Countries
{
    public class CountryAddDTO
    {
        [Required(ErrorMessage = CountryValidation.RequiredPersianNameError)]
        [StringLength(128, ErrorMessage = CountryValidation.LengthError)]
        [RegularExpression("^[آابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهی\\s]+$", ErrorMessage = CountryValidation.InvalidPersianNameError)]
        public string PersianName { get; set; }


        [Required(ErrorMessage = CountryValidation.RequiredEnglishNameError)]
        [StringLength(128, ErrorMessage = CountryValidation.LengthError)]
        [RegularExpression("^[a-zA-Z\\s]*$", ErrorMessage = CountryValidation.InvalidEnglishNameError)]
        public string EnglishName { get; set; }

    }
}
