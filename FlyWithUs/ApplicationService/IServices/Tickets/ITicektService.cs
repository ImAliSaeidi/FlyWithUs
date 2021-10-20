using FlyWithUs.Hosted.Service.DTOs.Orders;
using FlyWithUs.Hosted.Service.DTOs.Tickets;
using System.Collections.Generic;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.Tickets
{
    public interface ITicektService
    {
        bool AddTicket(TicketAddDTO dto, string userid);

        bool DeleteTickets(string userid);

        bool CancelTicket(TicketCancelDTO dto);
    }
}
