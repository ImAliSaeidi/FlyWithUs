using AutoMapper;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.Orders;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Orders;
using FlyWithUs.Hosted.Service.DTOs.Travels;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Orders;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Tickets;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Travels;
using FlyWithUs.Hosted.Service.Tools.Convertors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository repository;
        private readonly ITravelRepository travelRepository;
        private readonly IOrderTicketRepository orderTicketRepository;
        private readonly ITicketRepository ticketRepository;
        private readonly IMapper mapper;

        public OrderService(IOrderRepository repository, IMapper mapper, IOrderTicketRepository orderTicketRepository, ITicketRepository ticketRepository, ITravelRepository travelRepository)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.orderTicketRepository = orderTicketRepository;
            this.ticketRepository = ticketRepository;
            this.travelRepository = travelRepository;
        }

        public List<PaymentResultDTO> Pay(string userid)
        {
            List<PaymentResultDTO> dtos = null;
            var order = repository.GetUserOpenOrder(userid);
            if (order != null)
            {
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

        public List<TravelViewDTO> GetOrderDetails(string userid)
        {
            var dtos = new List<TravelViewDTO>();
            var order = repository.GetUserOpenOrder(userid);
            foreach (var item in order.OrderTickets)
            {
                var dto = mapper.Map<TravelViewDTO>(travelRepository.GetViewById(item.Ticket.TravelId));
                dto.MovingDate = item.Ticket.Travel.MovingDate.ToShamsi();
                dto.ArrivingDate = item.Ticket.Travel.ArrivingDate.ToShamsi();
                dto.MovingTime = item.Ticket.Travel.MovingTime.ToString("HH:mm");
                dto.ArrivingTime = item.Ticket.Travel.ArrivingTime.ToString("HH:mm");
                dto.Price = item.Ticket.Travel.Price.ToString("N0");
                dtos.Add(dto);
            }
            return dtos;
        }

        public GridResultDTO<PaymentResultDTO> GetUserOrder(string userid, int skip, int take)
        {
            var resultViews = repository.GetUserOrders(userid).OrderByDescending(o => o.TicketCreateDate).Skip(skip).Take(take).ToList();
            var dtos = new List<PaymentResultDTO>();
            foreach (var item in resultViews)
            {
                var dto = mapper.Map<PaymentResultDTO>(item);
                dto.MovingDate = item.MovingDate.ToShamsi();
                dto.MovingTime = item.MovingTime.ToString("HH:mm");
                if (item.MovingDate > DateTime.Now)
                {
                    dto.Cancelable = true;
                }
                dtos.Add(dto);
            }
            int count = repository.GetUserOrders(userid).ToList().Count;
            return new GridResultDTO<PaymentResultDTO>(count, dtos);
        }
    }
}
