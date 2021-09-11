using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Models.Travels
{
    public class MultiPartTravel : BaseEntity
    {
        [Required]
        [StringLength(128)]
        public string Origin { get; set; }


        [Required]
        [StringLength(128)]
        public string Destination { get; set; }

        public Travel Travel { get; set; }
    }
}
