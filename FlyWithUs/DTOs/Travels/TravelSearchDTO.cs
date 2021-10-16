using System;

namespace FlyWithUs.Hosted.Service.DTOs.Travels
{
    public class TravelSearchDTO
    {
        public TravelSearchDTO(string movingdate,string backingdate)
        {
            MovingDate = Convert.ToDateTime(movingdate);
            BackingDate = Convert.ToDateTime(backingdate);
        }
        public string Origin { get; set; }

        public string Destination { get; set; }

        public DateTime MovingDate { get; set; }

        public DateTime BackingDate { get; set; }
    }
}
