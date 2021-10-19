using FlyWithUs.Hosted.Service.Models.Tickets;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Tickets
{
    public interface ITicketRepository
    {
        int Add(Ticket ticket);

        int Delete(int ticketid);

        Ticket GetById(int ticketid);

        int Update(Ticket ticket);

        int Save();
    }
}
