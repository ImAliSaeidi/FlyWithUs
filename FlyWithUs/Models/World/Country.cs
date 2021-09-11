using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Models.World
{
    public class Country : BaseEntity
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        [StringLength(2)]
        public string ISO2 { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }


        [Required]
        [StringLength(128)]
        public string NiceName { get; set; }


        [StringLength(3)]
        public string ISO3 { get; set; }


        [MaxLength(6)]
        public short? NumCode { get; set; }


        [MaxLength(5)]
        public short? PhoneCode { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
