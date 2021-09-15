using FlyWithUs.Hosted.Service.Models.Travels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Models.World
{
    public class Airport : BaseEntity
    {
        public Airport()
        {
            IncomingTravels = new HashSet<Travel>();
            OutboundTravels = new HashSet<Travel>();
        }


        [Required]
        [StringLength(128)]
        public string Name { get; set; }


        [Required]
        [StringLength(128)]
        public string EnglishName { get; set; }


        [Required]
        [StringLength(4)]
        public string Code { get; set; }


        public City City { get; set; }


        [InverseProperty("DestinationAirport")]
        public ICollection<Travel> IncomingTravels { get; set; }



        [InverseProperty("OriginAirport")]
        public ICollection<Travel> OutboundTravels { get; set; }
    }
}
