using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Orders;
using FlyWithUs.Hosted.Service.DTOs.Travels;
using System.Collections.Generic;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.Orders
{
    public interface IOrderService
    {
        List<PaymentResultDTO> Pay(string userId);

        bool DeleteNotFinalyOrders(string userId);

        List<TravelViewDTO> GetOrderDetails(string userId);

        GridResultDTO<PaymentResultDTO> GetUserOrder(string userId, int skip, int take);
    }
}
