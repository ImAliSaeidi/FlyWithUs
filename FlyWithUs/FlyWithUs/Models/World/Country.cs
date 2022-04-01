using FlyWithUs.Hosted.Service.Models.Travels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlyWithUs.Hosted.Service.Models.World
{
    public class Country : BaseEntity
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

       
        [Required]
        [StringLength(128)]
        public string EnglishName { get; set; }


        [Required]
        [StringLength(128)]
        public string PersianName { get; set; }

  
        public ICollection<City> Cities { get; set; }

        [InverseProperty("DestinationCountry")]
        public ICollection<Travel> IncomingTravels { get; set; }

        [InverseProperty("OriginCountry")]
        public ICollection<Travel> OutboundTravels { get; set; }
    }
}
