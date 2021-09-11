using FlyWithUs.Models.Tickets;
using FlyWithUs.Models.World;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Models.Travels
{
    public class Travel : BaseEntity
    {
        public Travel()
        {
            TravelDetails = new HashSet<TravelDetail>();
            Tickets = new HashSet<Ticket>();
            MultiPartTravels = new HashSet<MultiPartTravel>();
        }

        [Required]
        [StringLength(16)]
        public string Code { get; set; }


        [Required]
        public int MaxCapacity { get; set; }

        public ICollection<TravelDetail> TravelDetails { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        public City OriginCity { get; set; }

        public City DestinationCity { get; set; }

        public ICollection<MultiPartTravel> MultiPartTravels { get; set; }
    }
}
