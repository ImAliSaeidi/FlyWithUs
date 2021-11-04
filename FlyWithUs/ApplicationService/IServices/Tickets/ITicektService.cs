using FlyWithUs.Hosted.Service.DTOs.Tickets;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.Tickets
{
    public interface ITicektService
    {
        bool AddTicket(TicketAddDTO dto, string userId);

        bool DeleteTickets(string userId);

        bool CancelTicket(TicketCancelDTO dto);
    }
}
