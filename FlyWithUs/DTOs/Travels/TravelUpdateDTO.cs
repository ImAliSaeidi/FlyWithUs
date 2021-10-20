using System;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.DTOs.Travels
{
    public class TravelUpdateDTO
    {
        public int Id { get; set; }


        public int SoldTicket { get; set; }


        public string Code { get; set; }


        public string Type { get; set; }


        [Required(ErrorMessage = TravelValidation.RequiredMaxCapacityError)]
        public int MaxCapacity { get; set; }


        [Required(ErrorMessage = TravelValidation.RequiredSelectOriginCountryError)]
        public int OriginCountryId { get; set; }


        [Required(ErrorMessage = TravelValidation.RequiredSelectDestinationCountryError)]
        public int DestinationCountryId { get; set; }



        [Required(ErrorMessage = TravelValidation.RequiredSelectOriginCityError)]
        public int OriginCityId { get; set; }


        [Required(ErrorMessage = TravelValidation.RequiredSelectDestinationCityError)]
        public int DestinationCityId { get; set; }


        [Required(ErrorMessage = TravelValidation.RequiredSelectAgancyError)]
        public int AgancyId { get; set; }


        [Required(ErrorMessage = TravelValidation.RequiredSelectAirplaneError)]
        public int AirplaneId { get; set; }


        [Required(ErrorMessage = TravelValidation.RequiredSelectOriginAirportError)]
        public int OriginAirportId { get; set; }


        [Required(ErrorMessage = TravelValidation.RequiredSelectDestinationAirportError)]
        public int DestinationAirportId { get; set; }


        [Required(ErrorMessage = TravelValidation.RequiredSelectMovingTimeError)]
        public DateTime MovingTime { get; set; }


        [Required(ErrorMessage = TravelValidation.RequiredSelectArrivingTimeError)]
        public DateTime ArrivingTime { get; set; }


        [Required(ErrorMessage = TravelValidation.RequiredSelectMovingDateError)]
        public DateTime MovingDate { get; set; }


        [Required(ErrorMessage = TravelValidation.RequiredSelectArrivingDateError)]
        public DateTime ArrivingDate { get; set; }


        [Required(ErrorMessage = TravelValidation.RequiredSelectClassError)]
        [StringLength(32)]
        public string Class { get; set; }


        [Required(ErrorMessage = TravelValidation.RequiredPriceError)]
        public int Price { get; set; }
    }
}
