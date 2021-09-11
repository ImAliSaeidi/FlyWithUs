using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Models.Airplanes
{
    public class Airplane : BaseEntity
    {
        #region Properties
        public string Name { get; set; }

        public string Brand { get; set; }

        public string Class { get; set; }

        public int MaxCapacity { get; set; }
        #endregion


        #region Relations
        public Agancy Agancy { get; set; }

        #endregion
    }
}
