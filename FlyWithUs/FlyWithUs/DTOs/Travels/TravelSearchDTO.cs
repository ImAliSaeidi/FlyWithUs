using System;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Travels
{
    public class TravelSearchDTO
    {
        public TravelSearchDTO(string movingdate)
        {
            MovingDate = Convert.ToDateTime(movingdate);
        }

        [Required(ErrorMessage =TravelValidation.RequiredSelectOriginCityError)]
        public string Origin { get; set; }


        [Required(ErrorMessage = TravelValidation.RequiredSelectDestinationCityError)]
        public string Destination { get; set; }


        [Required(ErrorMessage = TravelValidation.RequiredSelectMovingDateError)]
        public DateTime MovingDate { get; set; }
                
        public string OrderBy { get; set; }
    }
}
