using FlyWithUs.Hosted.Service.Infrastructure.Context;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Orders;
using FlyWithUs.Hosted.Service.Models.Orders;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.Repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FlyWithUsContext context;

        public OrderRepository(FlyWithUsContext context)
        {
            this.context = context;
        }

        public int Add(Order order)
        {
            context.Orders.Add(order);
            return Save();
        }

        public int Delete(int orderId)
        {
            var order = GetById(orderId);
            order.IsDeleted = true;
            return Update(order);
        }

        public Order GetById(int orderId)
        {
            return context.Orders
                .Include(o => o.OrderTickets)
                .ThenInclude(ot => ot.Ticket)
                .FirstOrDefault(o => o.Id == orderId);
        }

        public PaymentResultView GetPaymentResult(int ticketId)
        {
            return context.PaymentResultViews.Find(ticketId);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public int Update(Order order)
        {
            context.Orders.Update(order);
            return Save();
        }

        public Order GetUserOpenOrder(string userId)
        {
            return context.Orders
                .Include(o => o.OrderTickets)
                .ThenInclude(ot => ot.Ticket)
                .ThenInclude(t => t.Travel)
                .FirstOrDefault(o => o.UserId == userId && o.IsFinaly == false);
        }

        public IQueryable<PaymentResultView> GetUserOrders(string userId)
        {
            return context.PaymentResultViews.Where(p => p.UserId == userId);
        }

        public IQueryable<Order> GetAll()
        {
            return context.Orders.Where(o => o.IsFinaly == true);
        }
    }
}
