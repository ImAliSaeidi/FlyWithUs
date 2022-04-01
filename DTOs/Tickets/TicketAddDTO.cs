using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Tickets
{
    public class TicketAddDTO
    {
        [Required(ErrorMessage = TicketValidation.RequiredTravelError)]
        public int TravelId { get; set; }
    }
}
