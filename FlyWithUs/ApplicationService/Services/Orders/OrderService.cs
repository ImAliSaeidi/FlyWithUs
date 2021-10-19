using AutoMapper;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.Orders;
using FlyWithUs.Hosted.Service.DTOs.Orders;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Orders;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Tickets;
using FlyWithUs.Hosted.Service.Tools.Convertors;
using System;
using System.Collections.Generic;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository repository;
        private readonly IOrderTicketRepository orderTicketRepository;
        private readonly ITicketRepository ticketRepository;
        private readonly IMapper mapper;

        public OrderService(IOrderRepository repository, IMapper mapper, IOrderTicketRepository orderTicketRepository, ITicketRepository ticketRepository)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.orderTicketRepository = orderTicketRepository;
            this.ticketRepository = ticketRepository;
        }

        public List<PaymentResultDTO> Pay(string userid)
        {
            List<PaymentResultDTO> dtos = null;
            var order = repository.GetUserOpenOrder(userid);
            if (order != null)
            {
                order.TrackingCode = (order.Id * 11) + Guid.NewGuid().ToString().Substring(0, 8 - (order.Id * 11).ToString().Length).ToUpper();
                order.IsFinaly = true;
                int count = repository.Update(order);
                if (count > 0)
                {
                    dtos = new List<PaymentResultDTO>();
                    foreach (var item in order.OrderTickets)
                    {
                        var resultView = repository.GetPaymentResult(item.TicketId);
                        var dto = mapper.Map<PaymentResultDTO>(resultView);
                        dto.MovingDate = resultView.MovingDate.ToShamsi();
                        dto.MovingTime = resultView.MovingTime.ToString("HH:mm");
                        dtos.Add(dto);
                    }
                }
            }
            return dtos;
        }

        public bool DeleteNotFinalyOrders(string userid)
        {
            var result = false;
            var order = repository.GetUserOpenOrder(userid);
            if (order != null)
            {
                foreach (var item in order.OrderTickets)
                {
                    orderTicketRepository.Delete(item.Id);
                    ticketRepository.Delete(item.TicketId);
                }

                int count = repository.Delete(order.Id);
                if (count > 0)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
