using FlyWithUs.Models.Travels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Models.World
{
    public class City : BaseEntity
    {
        public City()
        {
            Airports = new HashSet<Airport>();
            IncomingTravels = new HashSet<Travel>();
            OutboundTravels = new HashSet<Travel>();
        }


        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public Country Country { get; set; }

        public ICollection<Airport> Airports { get; set; }

        [InverseProperty("DestinationCity")]
        public ICollection<Travel> IncomingTravels { get; set; }



        [InverseProperty("OriginCity")]
        public ICollection<Travel> OutboundTravels { get; set; }
    }
}
