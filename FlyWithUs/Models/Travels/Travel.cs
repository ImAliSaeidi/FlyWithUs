using FlyWithUs.Hosted.Service.Models.Airplanes;
using FlyWithUs.Hosted.Service.Models.Tickets;
using FlyWithUs.Hosted.Service.Models.World;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlyWithUs.Hosted.Service.Models.Travels
{
    public class Travel : BaseEntity
    {
        public Travel()
        {
            Tickets = new HashSet<Ticket>();
        }

        [Required]
        [StringLength(16)]
        public string Code { get; set; }


        [Required]
        public int MaxCapacity { get; set; }


        [Required]
        public DateTime MovingTime { get; set; }


        [Required]
        public DateTime ArrivingTime { get; set; }


        [Required]
        public DateTime MovingDate { get; set; }


        [Required]
        public DateTime ArrivingDate { get; set; }


        [Required]
        [StringLength(32)]
        public string Type { get; set; }


        [Required]
        [StringLength(32)]
        public string Class { get; set; }


        [Required]
        public int Price { get; set; }


        [Required]
        public int AirplaneId { get; set; }

        [Required]
        public int AgancyId { get; set; }

        [Required]
        public int OriginAirportId { get; set; }


        [Required]
        public int DestinationAirportId { get; set; }


        [Required]
        public int OriginCityId { get; set; }


        [Required]
        public int DestinationCityId { get; set; }


        [Required]
        public int OriginCountryId { get; set; }


        [Required]
        public int DestinationCountryId { get; set; }


        public ICollection<Ticket> Tickets { get; set; }

        public Airplane Airplane { get; set; }

        public Agancy Agancy { get; set; }

        public Airport OriginAirport { get; set; }

        public Airport DestinationAirport { get; set; }

        public City OriginCity { get; set; }

        public City DestinationCity { get; set; }

        public Country OriginCountry { get; set; }

        public Country DestinationCountry { get; set; }

    }
}
