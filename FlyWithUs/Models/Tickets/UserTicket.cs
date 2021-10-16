using FlyWithUs.Hosted.Service.Models.Users;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlyWithUs.Hosted.Service.Models.Tickets
{
    public class UserTicket : BaseEntity
    {
        [ForeignKey("User")]
        [Required]
        public string UserId { get; set; }

        [Required]
        public int TicketId { get; set; }

        public bool IsFinaly { get; set; }

        public ApplicationUser User { get; set; }

        public Ticket Ticket { get; set; }
    }
}
