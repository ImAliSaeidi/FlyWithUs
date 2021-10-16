using FlyWithUs.Hosted.Service.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Tickets
{
    public interface ITicketRepository
    {
        int AddTicket(Ticket ticket);

        int Save();
    }
}
