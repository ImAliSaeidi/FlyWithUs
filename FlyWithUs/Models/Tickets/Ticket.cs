using FlyWithUs.Hosted.Service.Models.Orders;
using FlyWithUs.Hosted.Service.Models.Travels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.Models.Tickets
{
    public class Ticket : BaseEntity
    {
        public Ticket()
        {
            OrderTickets = new HashSet<OrderTicket>();
        }

        [Required]
        [StringLength(512)]
        public string Code { get; set; }


        [Required]
        public int TravelId { get; set; }

        public ICollection<OrderTicket> OrderTickets { get; set; }

        public Travel Travel { get; set; }
    }
}
