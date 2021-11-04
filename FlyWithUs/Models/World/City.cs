using FlyWithUs.Hosted.Service.Models.Travels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlyWithUs.Hosted.Service.Models.World
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
        public string PersianName { get; set; }


        [Required]
        [StringLength(128)]
        public string EnglishName { get; set; }


        //[Required]
        //[StringLength(1024)]
        //public string ImagePath { get; set; }


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
