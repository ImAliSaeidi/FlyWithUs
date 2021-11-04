﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Cities
{
    public class CityAddDTO
    {
        [Required(ErrorMessage = CityValidation.RequiredPersianNameError)]
        [StringLength(128, ErrorMessage = CityValidation.LengthError)]
        [RegularExpression("^[آابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهی\\s]+$", ErrorMessage = CityValidation.InvalidPersianNameError)]
        public string PersianName { get; set; }


        [Required(ErrorMessage = CityValidation.RequiredEnglishNameError)]
        [StringLength(128, ErrorMessage = CityValidation.LengthError)]
        [RegularExpression("^[a-zA-Z\\s]*$", ErrorMessage = CityValidation.InvalidEnglishNameError)]
        public string EnglishName { get; set; }


        [Required(ErrorMessage = CityValidation.RequiredSelectCountryError)]
        public int CountryId { get; set; }

    }
}
