using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Countries
{
    public class CountryUpdateDTO
    {
        public int Id { get; set; }


        [Required(ErrorMessage = CountryValidation.RequiredPersianNameError)]
        [StringLength(128, ErrorMessage = CountryValidation.LengthError)]
        [RegularExpression(CountryValidation.PersianNameRegex, ErrorMessage = CountryValidation.InvalidPersianNameError)]
        public string PersianName { get; set; }


        [Required(ErrorMessage = CountryValidation.RequiredEnglishNameError)]
        [StringLength(128, ErrorMessage = CountryValidation.LengthError)]
        [RegularExpression(CountryValidation.EnglishNameRegex, ErrorMessage = CountryValidation.InvalidEnglishNameError)]
        public string EnglishName { get; set; }
    }
}
