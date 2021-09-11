using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
