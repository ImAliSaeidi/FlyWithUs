using System;

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
