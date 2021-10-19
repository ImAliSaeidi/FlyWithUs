using FlyWithUs.Hosted.Service.Models.Travels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.Models.Airplanes
{
    public class Airplane : BaseEntity
    {
        public Airplane()
        {
            Travels = new HashSet<Travel>();
        }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }


        [Required]
        [StringLength(128)]
        public string Brand { get; set; }


        [Required]
        public int MaxCapacity { get; set; }


        [Required]
        public int AgancyId { get; set; }


        public Agancy Agancy { get; set; }

        public ICollection<Travel> Travels { get; set; }

    }
}
