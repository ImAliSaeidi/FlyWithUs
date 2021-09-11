using FlyWithUs.Models.Travels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Models.World
{
    public class Airport : BaseEntity
    {
        public Airport()
        {
            IncomingTravelDetails = new HashSet<TravelDetail>();
            OutboundTravelDetails = new HashSet<TravelDetail>();
        }


        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public City City { get; set; }


        [InverseProperty("DestinationAirport")]
        public ICollection<TravelDetail> IncomingTravelDetails { get; set; }



        [InverseProperty("OriginAirport")]
        public ICollection<TravelDetail> OutboundTravelDetails { get; set; }
    }
}
