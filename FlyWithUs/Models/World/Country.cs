using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Models.World
{
    public class Country : BaseEntity
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }


        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
