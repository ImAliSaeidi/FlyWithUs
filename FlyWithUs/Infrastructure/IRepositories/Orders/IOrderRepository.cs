using FlyWithUs.Hosted.Service.Models.Orders;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Orders
{
    public interface IOrderRepository
    {
        int Add(Order order);

        int Update(Order order);

        int Delete(int orderid);

        Order GetById(int orderid);

        PaymentResultView GetPaymentResult(int ticketid);

        Order GetUserOpenOrder(string userid);

        int Save();

        IQueryable<PaymentResultView> GetUserOrders(string userid); 
    }
}
