using FlyWithUs.Hosted.Service.Models.Orders;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Orders
{
    public interface IOrderRepository
    {
        int Add(Order order);

        int Update(Order order);

        int Delete(int orderId);

        Order GetById(int orderId);

        PaymentResultView GetPaymentResult(int ticketId);

        Order GetUserOpenOrder(string userId);

        int Save();

        IQueryable<PaymentResultView> GetUserOrders(string userId);

        IQueryable<Order> GetAll();
    }
}
