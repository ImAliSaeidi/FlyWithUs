using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Airports
{
    public class AirportUpdateDTO
    {
        public int Id { get; set; }


        [Required(ErrorMessage = AirportValidation.RequiredPersianNameError)]
        [StringLength(128, ErrorMessage = AirportValidation.LengthError)]
        public string Name { get; set; }


        [Required(ErrorMessage = AirportValidation.RequiredEnglishNameError)]
        [StringLength(128, ErrorMessage = AirportValidation.LengthError)]
        public string EnglishName { get; set; }


        [Required(ErrorMessage = AirportValidation.RequiredSelectCityError)]
        public int CityId { get; set; }
    }
}
