using FlyWithUs.Hosted.Service.Models.Tickets;
using FlyWithUs.Hosted.Service.Models.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlyWithUs.Hosted.Service.Models.Orders
{
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderTickets = new HashSet<OrderTicket>();
        }

        [ForeignKey("User")]
        [Required]
        public string UserId { get; set; }

        [Required]
        public int TotalPrice { get; set; }

        public bool IsFinaly { get; set; }

        [StringLength(256)]
        public string TrackingCode { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<OrderTicket> OrderTickets { get; set; }
    }
}
