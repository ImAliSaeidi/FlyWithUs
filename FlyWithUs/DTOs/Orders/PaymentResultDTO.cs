namespace FlyWithUs.Hosted.Service.DTOs.Orders
{
    public class PaymentResultDTO
    {
        public int TicketId { get; set; }

        public string TicketCode { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public string TrackingCode { get; set; }

        public string MovingDate { get; set; }

        public string MovingTime { get; set; }
    }
}
