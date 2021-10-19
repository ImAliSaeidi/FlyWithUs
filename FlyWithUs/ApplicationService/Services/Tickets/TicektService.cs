using FlyWithUs.Hosted.Service.ApplicationService.IServices.Tickets;
using FlyWithUs.Hosted.Service.DTOs.Tickets;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Orders;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Tickets;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Travels;
using FlyWithUs.Hosted.Service.Models.Orders;
using FlyWithUs.Hosted.Service.Models.Tickets;
using System;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.Tickets
{
    public class TicektService : ITicektService
    {
        private readonly ITicketRepository repository;
        private readonly ITravelRepository travelRepository;
        private readonly IOrderRepository orderRepository;

        public TicektService(ITicketRepository repository, ITravelRepository travelRepository, IOrderRepository orderRepository)
        {
            this.repository = repository;
            this.travelRepository = travelRepository;
            this.orderRepository = orderRepository;
        }

        public bool AddTicket(TicketAddDTO dto, string userid)
        {
            bool result = false;
            var travel = travelRepository.GetById(dto.TravelId);
            var remainingCapacity = travel.MaxCapacity - travel.Tickets.Count;
            if (remainingCapacity > 0)
            {
                string code = dto.TravelId.ToString() + Guid.NewGuid().ToString().Substring(0, 7).ToUpper();
                Ticket ticket = new Ticket();
                ticket.Code = code;
                ticket.TravelId = dto.TravelId;
                var order = orderRepository.GetUserOpenOrder(userid);
                if (order == null)
                {
                    order = new Order();
                    order.UserId = userid;
                    order.TotalPrice = travel.Price;
                    orderRepository.Add(order);
                }
                else
                {
                    order.TotalPrice += travel.Price;
                    orderRepository.Update(order);
                }
                OrderTicket orderTicket = new OrderTicket()
                {
                    OrderId = order.Id,
                    TicketId = ticket.Id
                };
                ticket.OrderTickets.Add(orderTicket);
                int count = repository.Add(ticket);
                if (count > 0)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
