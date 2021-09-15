using FlyWithUs.Hosted.Service.Models.Travels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Models.Airplanes
{
    public class Agancy : BaseEntity
    {
        public Agancy()
        {
            Airplanes = new HashSet<Airplane>();
        }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public ICollection<Airplane> Airplanes { get; set; }

    }
}
