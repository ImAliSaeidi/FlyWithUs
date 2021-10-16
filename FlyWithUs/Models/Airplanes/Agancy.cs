using FlyWithUs.Hosted.Service.Models.Travels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.Models.Airplanes
{
    public class Agancy : BaseEntity
    {
        public Agancy()
        {
            Airplanes = new HashSet<Airplane>();
            Travels = new HashSet<Travel>();
        }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public ICollection<Airplane> Airplanes { get; set; }

        public ICollection<Travel> Travels { get; set; }

    }
}
