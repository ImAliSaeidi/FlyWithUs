using FlyWithUs.Hosted.Service.Models.Tickets;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Tickets
{
    public interface ITicketRepository
    {
        int Add(Ticket ticket);

        int Delete(int ticketId);

        Ticket GetById(int ticketId);

        int Update(Ticket ticket);

        int Save();
    }
}
