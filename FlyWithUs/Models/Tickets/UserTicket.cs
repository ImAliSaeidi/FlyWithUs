using FlyWithUs.Hosted.Service.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Models.Tickets
{
    public class UserTicket : BaseEntity
    {
        public User User { get; set; }

        public Ticket Ticket { get; set; }
    }
}
