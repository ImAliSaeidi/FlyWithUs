using System;

namespace FlyWithUs.Hosted.Service.DTOs.Orders
{
    public class PaymentResultDTO
    {
        public int TicketId { get; set; }

        public string TicketCode { get; set; }

        public string OriginAirport { get; set; }

        public string DestinationAirport { get; set; }

        public string TrackingCode { get; set; }

        public string MovingDate { get; set; }

        public string MovingTime { get; set; }

        public bool Cancelable { get; set; }

        public DateTime TicketCreateDate { get; set; }
    }
}
