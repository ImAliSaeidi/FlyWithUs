using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Orders;
using FlyWithUs.Hosted.Service.DTOs.Travels;
using FlyWithUs.Hosted.Service.Models.Travels;
using System.Collections.Generic;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.Orders
{
    public interface IOrderService
    {
        List<PaymentResultDTO> Pay(string userid);

        bool DeleteNotFinalyOrders(string userid);

        List<TravelViewDTO> GetOrderDetails(string userid);

        GridResultDTO<PaymentResultDTO> GetUserOrder(string userid,int skip, int take);
    }
}
