using FlyWithUs.Models.Travels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Models.Tickets
{
    public class Ticket : BaseEntity
    {
        public Ticket()
        {
            UserTickets = new HashSet<UserTicket>();
        }

        [Required]
        [StringLength(16)]
        public string Code { get; set; }

        public ICollection<UserTicket> UserTickets { get; set; }

        public Travel Travel { get; set; }
    }
}
