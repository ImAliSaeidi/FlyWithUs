using FlyWithUs.Hosted.Service.ApplicationService.IServices.Travels;
using FlyWithUs.Hosted.Service.DTOs.Travels;
using FlyWithUs.Hosted.Service.Infrastructure.Repositories.Travels;
using FlyWithUs.Hosted.Service.Infrastructure.Repositories.World;
using FlyWithUs.Hosted.Service.Models.Travels;
using FlyWithUs.Hosted.Service.Tools.Convertors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.Travels
{
    public class TravelService : ITravelService
    {
        private readonly TravelRepository repository;
        private readonly AirportRepository airportRepository;
        public TravelService()
        {
            repository = new TravelRepository();
            airportRepository = new AirportRepository();
        }


        #region Add Travel
        public bool AddTravel(TravelAddDTO dto)
        {
            bool result = false;
            int travelid = repository.AddTravel(Map(dto));
            if (travelid > 0)
            {
                result = true;
            }
            return result;
        }

        private Travel Map(TravelAddDTO dto)
        {
            Travel travel = new Travel();
            var originairport = airportRepository.GetAirportById(dto.OriginAirportId);
            var destinationairport = airportRepository.GetAirportById(dto.DestinationAirportId);
            string org = dto.OriginAirportId.ToString();
            string dest = dto.DestinationAirportId.ToString();
            travel.Code = (org + dest + Guid.NewGuid()).Substring(0, 10).ToUpper();
            travel.MaxCapacity = dto.MaxCapacity;
            travel.MovingTime = dto.MovingTime;
            travel.ArrivingTime = dto.ArrivingTime;
            travel.MovingDate = dto.MovingDate;
            travel.ArrivingDate = dto.ArrivingDate;
            travel.Type = dto.Type;
            travel.Class = dto.Class;
            travel.Price = dto.Price;
            travel.OriginAirport = originairport;
            travel.DestinationAirport = destinationairport;
            originairport.OutboundTravels.Add(travel);
            destinationairport.IncomingTravels.Add(travel);
            airportRepository.UpdateAirport(originairport);
            airportRepository.UpdateAirport(destinationairport);
            return travel;
        }
        #endregion


        #region Delete Travel
        public bool DeleteTravel(int travelid)
        {
            bool result = false;
            int count = repository.DeleteTravel(travelid);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }
        #endregion


        #region Get Travel
        public List<TravelDTO> GetAllTravel()
        {
            List<TravelDTO> dtos = new List<TravelDTO>();
            List<Travel> travels = repository.GetAllTravel();
            foreach (var item in travels)
            {
                dtos.Add(Map(item));
            }
            return dtos;
        }

        public TravelDTO GetTravelById(int travelid)
        {
            return Map(repository.GetTravelById(travelid));
        }

        private TravelDTO Map(Travel travel)
        {
            return new TravelDTO
            {
                Id = travel.Id,
                Code = travel.Code,
                MaxCapacity = travel.MaxCapacity,
                SaledTicket = travel.Tickets.Count,
                Price = travel.Price,
                OriginCityName = travel.OriginAirport.City.Name,
                DestinationCityName = travel.DestinationAirport.City.Name,
                OriginAirportName = travel.OriginAirport.Name,
                DestinationAirportName = travel.DestinationAirport.Name,
                MovingTime = travel.MovingTime.ToShortTimeString(),
                ArrivingTime = travel.ArrivingTime.ToShortTimeString(),
                MovingDate = travel.MovingDate.ToShamsi(),
                ArrivingDate = travel.ArrivingDate.ToShamsi(),
                Type = travel.Type,
                Class = travel.Class
            };
        }
        #endregion


        #region Update Travel
        public TravelUpdateDTO GetTravelForUpdate(int travelid)
        {
            var travel = repository.GetTravelById(travelid);
            return new TravelUpdateDTO
            {
                Id = travel.Id,
                OriginAirportId = travel.OriginAirport.Id,
                DestinationAirportId = travel.DestinationAirport.Id,
                MaxCapacity = travel.MaxCapacity,
                MovingTime = travel.MovingTime,
                ArrivingTime = travel.ArrivingTime,
                MovingDate = travel.MovingDate,
                ArrivingDate = travel.ArrivingDate,
                Type = travel.Type,
                Class = travel.Class,
                Price = travel.Price
            };
        }

        public bool UpdateTravel(TravelUpdateDTO dto)
        {
            bool result = false;
            int count = repository.UpdateTravel(Map(dto));
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        private Travel Map(TravelUpdateDTO dto)
        {
            var travel = repository.GetTravelById(dto.Id);
            if (travel.OriginAirport.Id != dto.OriginAirportId)
            {
                var orgairport = airportRepository.GetAirportById(dto.OriginAirportId);
                travel.OriginAirport = orgairport;
                orgairport.OutboundTravels.Add(travel);
                airportRepository.UpdateAirport(orgairport);
            }
            if (travel.DestinationAirport.Id != dto.DestinationAirportId)
            {
                var destairport = airportRepository.GetAirportById(dto.DestinationAirportId);
                travel.DestinationAirport = destairport;
                destairport.IncomingTravels.Add(travel);
                airportRepository.UpdateAirport(destairport);
            }
            string org = dto.OriginAirportId.ToString();
            string dest = dto.DestinationAirportId.ToString();
            travel.Code = (org + dest + Guid.NewGuid()).Substring(0, 10).ToUpper();
            return travel;
        }
        #endregion
    }
}
