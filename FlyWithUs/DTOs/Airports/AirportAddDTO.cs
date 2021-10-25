﻿using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Airports
{
    public class AirportAddDTO
    {
        
        [Required(ErrorMessage = AirportValidation.RequiredPersianNameError)]
        [StringLength(128, ErrorMessage = AirportValidation.LengthError)]
        public string PersianName { get; set; }


        [Required(ErrorMessage = AirportValidation.RequiredEnglishNameError)]
        [StringLength(128, ErrorMessage = AirportValidation.LengthError)]
        public string EnglishName { get; set; }


        [Required(ErrorMessage = AirportValidation.RequiredSelectCityError)]
        public int CityId { get; set; }
    }
}
