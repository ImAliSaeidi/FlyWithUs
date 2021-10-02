using System;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Travels
{
    public class TravelAddDTO
    {
        public string Code { get; set; }


        public string Type { get; set; }


        [Display(Name = "حداکثر ظرفیت")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredInput)]
        public int MaxCapacity { get; set; }


        [Display(Name = "کشور مبدا")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredSelect)]
        public int OriginCountryId { get; set; }


        [Display(Name = "کشور مقصد")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredSelect)]
        public int DestinationCountryId { get; set; }



        [Display(Name = "شهر مبدا")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredSelect)]
        public int OriginCityId { get; set; }


        [Display(Name = "شهر مقصد")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredSelect)]
        public int DestinationCityId { get; set; }


        [Display(Name = "آژانس هواپیمایی")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredSelect)]
        public int AgancyId { get; set; }


        [Display(Name = "هواپیما")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredSelect)]
        public int AirplaneId { get; set; }


        [Display(Name = "فرودگاه مبدا")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredSelect)]
        public int OriginAirportId { get; set; }


        [Display(Name = "فرودگاه مقصد")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredSelect)]
        public int DestinationAirportId { get; set; }


        [Display(Name = "ساعت پرواز")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredSelect)]
        public DateTime MovingTime { get; set; }


        [Display(Name = "ساعت رسیدن به مقصد")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredSelect)]
        public DateTime ArrivingTime { get; set; }


        [Display(Name = "تاریخ پرواز")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredSelect)]
        public DateTime MovingDate { get; set; }


        [Display(Name = "تاریخ رسیدن به مقصد")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredSelect)]
        public DateTime ArrivingDate { get; set; }


        [Display(Name = "کلاس پرواز")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredSelect)]
        [StringLength(32)]
        public string Class { get; set; }


        [Display(Name = "قیمت هر بلیط(بزرگسال)")]
        [Required(ErrorMessage = CustomDTOValidation.RequiredInput)]
        public int Price { get; set; }

    }
}
