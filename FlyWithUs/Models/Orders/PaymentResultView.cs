using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Models.Orders
{
    public class PaymentResultView
    {
        public int TicketId { get; set; }

        public string TicketCode { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public string TrackingCode { get; set; }

        public DateTime MovingDate { get; set; }

        public DateTime MovingTime { get; set; }
    }
}
