using FlyWithUs.Hosted.Service.Infrastructure.Context;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Tickets;
using FlyWithUs.Hosted.Service.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Infrastructure.Repositories.Tickets
{
    public class TicketRepository : ITicketRepository
    {
        private readonly FlyWithUsContext context;

        public TicketRepository(FlyWithUsContext context)
        {
            this.context = context;
        }

        public int AddTicket(Ticket ticket)
        {
            context.Tickets.Add(ticket);
            return Save();
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
