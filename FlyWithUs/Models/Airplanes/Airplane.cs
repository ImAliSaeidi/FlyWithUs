using FlyWithUs.Models.Travels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Models.Airplanes
{
    public class Airplane : BaseEntity
    {
        public Airplane()
        {
            Traveldetails = new HashSet<TravelDetail>();
        }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }


        [Required]
        [StringLength(128)]
        public string Brand { get; set; }


        [Required]
        public int MaxCapacity { get; set; }

        public Agancy Agancy { get; set; }

        public ICollection<TravelDetail> Traveldetails { get; set; }

    }
}
