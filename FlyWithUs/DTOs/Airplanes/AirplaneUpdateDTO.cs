﻿using FlyWithUs.Hosted.Service.Models.Airplanes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Airplanes
{
    public class AirplaneUpdateDTO
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "لطفا نام هواپیما را وارد کنید")]
        [StringLength(128, ErrorMessage = "طول ورودی بیش از حد مجاز است")]
        public string Name { get; set; }


        [Required(ErrorMessage = "لطفا برند هواپیما را وارد کنید")]
        [StringLength(128, ErrorMessage = "طول ورودی بیش از حد مجاز است")]
        public string Brand { get; set; }


        [Required(ErrorMessage = "لطفا ظرفیت هواپیما را وارد کنید")]
        public int MaxCapacity { get; set; }



        [Required(ErrorMessage = "لطفا تعداد هواپیما را وارد کنید")]
        public int Count { get; set; }


        [Required(ErrorMessage = "لطفا آژانس هواپیمایی را انتخاب کنید")]
        public int AgancyId { get; set; }
    }
}