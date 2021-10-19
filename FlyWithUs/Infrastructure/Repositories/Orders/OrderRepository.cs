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

        public int Delete(int orderid)
        {
            var order = GetById(orderid);
            order.IsDeleted = true;
            return Update(order);
        }

        public Order GetById(int orderid)
        {
            return context.Orders
                .Include(o => o.OrderTickets)
                .ThenInclude(ot => ot.Ticket)
                .FirstOrDefault(o => o.Id == orderid);
        }

        public PaymentResultView GetPaymentResult(int ticketid)
        {
            return context.PaymentResultViews.Find(ticketid);
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

        public Order GetUserOpenOrder(string userid)
        {
            return context.Orders
                .Include(o => o.OrderTickets)
                .FirstOrDefault(o => o.UserId == userid && o.IsFinaly == false);
        }
    }
}
