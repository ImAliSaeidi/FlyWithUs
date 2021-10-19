using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Cities
{
    public class CityAddDTO
    {
        [Required(ErrorMessage = CityValidation.RequiredPersianNameError)]
        [StringLength(128, ErrorMessage = CityValidation.LengthError)]
        public string PersianName { get; set; }


        [Required(ErrorMessage = CityValidation.RequiredEnglishNameError)]
        [StringLength(128, ErrorMessage = CityValidation.LengthError)]
        public string EnglishName { get; set; }


        [Required(ErrorMessage = CityValidation.RequiredSelectError)]
        public int CountryId { get; set; }


        [Required(ErrorMessage = CityValidation.RequiredImageError)]
        public IFormFile Image { get; set; }
    }
}
