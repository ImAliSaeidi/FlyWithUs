using System;

namespace FlyWithUs.Hosted.Service.DTOs.Travels
{
    public class TravelSearchDTO
    {
        public TravelSearchDTO(string movingdate)
        {
            MovingDate = Convert.ToDateTime(movingdate);
        }
        public string Origin { get; set; }

        public string Destination { get; set; }

        public DateTime MovingDate { get; set; }
                
        public string OrderBy { get; set; }
    }
}
