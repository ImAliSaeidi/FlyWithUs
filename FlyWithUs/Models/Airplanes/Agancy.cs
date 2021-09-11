using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Models.Airplanes
{
    public class Agancy : BaseEntity
    {
        public Agancy()
        {
            Airplanes = new HashSet<Airplane>();
        }


        public string Name { get; set; }

        public ICollection<Airplane> Airplanes { get; set; }

    }
}
