using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Travels
{
    public class TravelAddDTO
    {
        [Required(ErrorMessage ="لطفا حداکثر ظرفیت را وارد کنید")]
        public int MaxCapacity { get; set; }


        public int OriginCountryId { get; set; }


        public int DestinationCountryId { get; set; }


        public int OriginCityId { get; set; }


        public int DestinationCityId { get; set; }


        public int AgancyId { get; set; }


        [Required(ErrorMessage = "لطفا هواپیما را انتخاب کنید")]
        public int AirplaneId { get; set; }


        [Required(ErrorMessage = "لطفا فرودگاه مبدا را انتخاب کنید")]
        public int OriginAirportId { get; set; }


        [Required(ErrorMessage = "لطفا فرودگاه مقصد را انتخاب کنید")]
        public int DestinationAirportId { get; set; }


        [Required(ErrorMessage = "لطفا ساعت پرواز را انتخاب کنید")]
        public DateTime MovingTime { get; set; }


        [Required(ErrorMessage = "لطفا ساعت رسیدن به مقصد را انتخاب کنید")]
        public DateTime ArrivingTime { get; set; }


        [Required(ErrorMessage = "لطفا تاریخ پرواز را انتخاب کنید")]
        public DateTime MovingDate { get; set; }


        [Required(ErrorMessage = "لطفا تاریخ رسیدن به مقصد را انتخاب کنید")]
        public DateTime ArrivingDate { get; set; }


        [Required(ErrorMessage = "لطفا نوع پرواز را انتخاب کنید")]
        [StringLength(32)]
        public string Type { get; set; }


        [Required(ErrorMessage = "لطفا کلاس پرواز انتخاب کنید")]
        [StringLength(32)]
        public string Class { get; set; }


        [Required(ErrorMessage = "لطفا قیمت هر بلیط(بزرگسال) را وارد کنید")]
        public int Price { get; set; }

    }
}
