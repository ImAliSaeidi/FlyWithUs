using FlyWithUs.Hosted.Service.Models.Users;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.Models.Tickets
{
    public class UserTicket : BaseEntity
    {
        [Required]
        public int UserId { get; set; }


        [Required]
        public int TicketId { get; set; }

        public ApplicationUser User { get; set; }

        public Ticket Ticket { get; set; }
    }
}
