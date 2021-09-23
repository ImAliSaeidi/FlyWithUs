using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Travels
{
    public class TravelUpdateDTO : TravelAddDTO
    {
        public int Id { get; set; }


        public int SaledTicket { get; set; }


        public string Type { get; set; }
    }
}
