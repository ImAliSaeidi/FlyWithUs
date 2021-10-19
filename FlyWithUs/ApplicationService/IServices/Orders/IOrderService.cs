using FlyWithUs.Hosted.Service.DTOs.Orders;
using System.Collections.Generic;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.Orders
{
    public interface IOrderService
    {
        List<PaymentResultDTO> Pay(string userid);

        bool DeleteNotFinalyOrders(string userid);
    }
}
