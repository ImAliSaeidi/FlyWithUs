using FlyWithUs.Hosted.Service.Infrastructure.Context;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Tickets;
using FlyWithUs.Hosted.Service.Models.Tickets;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.Repositories.Tickets
{
    public class TicketRepository : ITicketRepository
    {
        private readonly FlyWithUsContext context;

        public TicketRepository(FlyWithUsContext context)
        {
            this.context = context;
        }

        public int Add(Ticket ticket)
        {
            context.Tickets.Add(ticket);
            return Save();
        }

        public int Delete(int ticketId)
        {
            var ticket = GetById(ticketId);
            ticket.IsDeleted = true;
            return Update(ticket);
        }

        public Ticket GetById(int ticketId)
        {
            return context.Tickets.Include(t => t.Travel).FirstOrDefault(t => t.Id == ticketId);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public int Update(Ticket ticket)
        {
            context.Tickets.Update(ticket);
            return Save();
        }
    }
}
