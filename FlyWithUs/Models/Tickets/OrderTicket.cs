using FlyWithUs.Hosted.Service.Models.Orders;
using FlyWithUs.Hosted.Service.Models.Users;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlyWithUs.Hosted.Service.Models.Tickets
{
    public class OrderTicket : BaseEntity
    {

        [ForeignKey("Order")]
        [Required]
        public int OrderId { get; set; }

        [Required]
        public int TicketId { get; set; }

        public Ticket Ticket { get; set; }

        public Order Order { get; set; }
    }
}
