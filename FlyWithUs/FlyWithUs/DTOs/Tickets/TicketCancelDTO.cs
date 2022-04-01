using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Tickets
{
    public class TicketCancelDTO
    {
        public string UserId { get; set; }

        [Required]
        public int TicketId { get; set; }
    }
}
