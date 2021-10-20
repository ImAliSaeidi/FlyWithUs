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
        private readonly IOrderTicketRepository orderTicketRepository;

        public TicektService(ITicketRepository repository, ITravelRepository travelRepository, IOrderRepository orderRepository, IOrderTicketRepository orderTicketRepository)
        {
            this.repository = repository;
            this.travelRepository = travelRepository;
            this.orderRepository = orderRepository;
            this.orderTicketRepository = orderTicketRepository;
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
                    order.TrackingCode = (order.Id * 11) + Guid.NewGuid().ToString().Substring(0, 8 - (order.Id * 11).ToString().Length).ToUpper();
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

        public bool CancelTicket(TicketCancelDTO dto)
        {
            var result = false;
            var orderTicket = orderTicketRepository.GetByTicketId(dto.TicketId);
            if (orderTicket != null)
            {
                var ticket = repository.GetById(orderTicket.TicketId);
                var order = orderRepository.GetById(orderTicket.OrderId);
                if (ticket != null)
                {
                    ticket.IsDeleted = true;
                    int count = repository.Update(ticket);
                    if (count > 0 && order != null)
                    {
                        order.TotalPrice -= ticket.Travel.Price;
                        if (order.TotalPrice == 0)
                        {
                            order.IsDeleted = true;
                        }
                        count = orderRepository.Update(order);
                        if (count > 0)
                        {
                            result = true;
                        }
                    }
                }
            }
            return result;
        }

        public bool DeleteTickets(string userid)
        {
            var result = false;
            var order = orderRepository.GetUserOpenOrder(userid);
            if (order != null)
            {
                foreach (var item in order.OrderTickets)
                {
                    orderTicketRepository.Delete(item.Id);
                    repository.Delete(item.TicketId);
                    order.TotalPrice -= item.Ticket.Travel.Price;
                }
                int count = orderRepository.Update(order);
                if (count > 0)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
