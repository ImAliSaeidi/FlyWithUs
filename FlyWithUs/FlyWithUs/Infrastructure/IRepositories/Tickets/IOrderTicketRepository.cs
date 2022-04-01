using FlyWithUs.Hosted.Service.Models.Tickets;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Tickets
{
    public interface IOrderTicketRepository
    {

        OrderTicket GetById(int orderTicketId);

        OrderTicket GetByTicketId(int ticketId);

        int Delete(int orderTicketId);

        int Update(OrderTicket orderTicket);

        int Save();
    }
}
