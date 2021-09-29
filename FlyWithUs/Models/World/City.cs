using FlyWithUs.Hosted.Service.Models.Travels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Models.World
{
    public class City : BaseEntity
    {
        public City()
        {
            Airports = new HashSet<Airport>();
        }


        [Required]
        [StringLength(128)]
        public string Name { get; set; }


        [Required]
        public int CountryId { get; set; }


        public Country Country { get; set; }

        public ICollection<Airport> Airports { get; set; }

        [InverseProperty("DestinationCity")]
        public ICollection<Travel> IncomingTravels { get; set; }

        [InverseProperty("OriginCity")]
        public ICollection<Travel> OutboundTravels { get; set; }

    }
}
