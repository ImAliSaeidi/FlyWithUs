using FlyWithUs.Hosted.Service.Infrastructure.Context;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Tickets;
using FlyWithUs.Hosted.Service.Models.Tickets;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.Repositories.Tickets
{
    public class OrderTicketRepository : IOrderTicketRepository
    {
        private readonly FlyWithUsContext context;

        public OrderTicketRepository(FlyWithUsContext context)
        {
            this.context = context;
        }

        public int Delete(int orderTicketId)
        {
            var orderTicket = GetById(orderTicketId);
            orderTicket.IsDeleted = true;
            return Update(orderTicket);
        }

        public OrderTicket GetById(int orderTicketId)
        {
            return context.OrderTickets.Find(orderTicketId);
        }

        public OrderTicket GetByTicketId(int ticketid)
        {
            return context.OrderTickets.FirstOrDefault(ot => ot.TicketId == ticketid);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public int Update(OrderTicket orderTicket)
        {
            context.OrderTickets.Update(orderTicket);
            return Save();
        }

    }
}
