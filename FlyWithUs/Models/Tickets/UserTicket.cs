using FlyWithUs.Hosted.Service.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Models.Tickets
{
    public class UserTicket : BaseEntity
    {
        [Required]
        public int UserId { get; set; }


        [Required]
        public int TicketId { get; set; }

        public User User { get; set; }

        public Ticket Ticket { get; set; }
    }
}
