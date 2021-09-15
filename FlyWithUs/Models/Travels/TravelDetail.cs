﻿using FlyWithUs.Hosted.Service.Models.Airplanes;
using FlyWithUs.Hosted.Service.Models.World;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Models.Travels
{
    public class TravelDetail : BaseEntity
    {

        #region Properties
        public int MaxCapacity { get; set; }


        [Required]
        [StringLength(16)]
        public string Code { get; set; }


        [Required]
        public DateTime MovingTime { get; set; }


        [Required]
        public DateTime ArrivingTime { get; set; }


        [Required]
        [StringLength(32)]
        public string Type { get; set; }



        [Required]
        [StringLength(32)]
        public string Class { get; set; }


        [Required]
        public int Price { get; set; }
        #endregion


        #region Relations
        public Travel Travel { get; set; }

        public Airport OriginAirport { get; set; }

        public Airport DestinationAirport { get; set; }

        public Airplane Airplane { get; set; }
        #endregion
    }
}
