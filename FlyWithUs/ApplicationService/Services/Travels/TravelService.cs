using FlyWithUs.Hosted.Service.ApplicationService.IServices.Airplanes;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.Travels;
using FlyWithUs.Hosted.Service.DTOs.Travels;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Airplanes;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Travels;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World;
using FlyWithUs.Hosted.Service.Infrastructure.Repositories.Travels;
using FlyWithUs.Hosted.Service.Infrastructure.Repositories.World;
using FlyWithUs.Hosted.Service.Models.Tickets;
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
        private readonly ITravelRepository repository;
        private readonly IAirportRepository airportRepository;
        private readonly IAirplaneRepository airplaneRepository;

        public TravelService(ITravelRepository repository,
            IAirportRepository airportRepository,
            IAirplaneRepository airplaneRepository
           )
        {
            this.repository = repository;
            this.airportRepository = airportRepository;
            this.airplaneRepository = airplaneRepository;

        }


        #region Add Travel
        public bool AddTravel(TravelAddDTO dto)
        {
            bool result = false;
            int travelid = repository.AddTravel(Map(dto));
            if (travelid > 0)
            {
                AddRelationsToTravel(travelid, dto);
                result = true;
            }
            return result;
        }

        private Travel Map(TravelAddDTO dto)
        {
            Travel travel = new Travel();
            string org = dto.OriginAirportId.ToString();
            string dest = dto.DestinationAirportId.ToString();
            travel.Code = (org + dest + Guid.NewGuid()).Substring(0, 10).ToUpper();
            travel.MaxCapacity = dto.MaxCapacity;
            travel.MovingTime = dto.MovingTime.ToShortTimeString();
            travel.ArrivingTime = dto.ArrivingTime.ToShortTimeString();
            travel.MovingDate = dto.MovingDate.ToShortDateString();
            travel.ArrivingDate = dto.ArrivingDate.ToShortDateString();
            if (dto.OriginCountryId == dto.DestinationCountryId)
            {
                travel.Type = "Domestic";
            }
            else
            {
                travel.Type = "International";
            }
            travel.Class = dto.Class;
            travel.Price = dto.Price;
            return travel;
        }

        private void AddRelationsToTravel(int travelid, TravelAddDTO dto)
        {
            Travel travel = repository.GetTravelById(travelid);
            var originairport = airportRepository.GetAirportById(dto.OriginAirportId);
            var destinationairport = airportRepository.GetAirportById(dto.DestinationAirportId);
            var airplane = airplaneRepository.GetAirplaneById(dto.AirplaneId);
            travel.OriginAirport = originairport;
            originairport.OutboundTravels.Add(travel);
            airportRepository.UpdateAirport(originairport);
            travel.DestinationAirport = destinationairport;
            destinationairport.IncomingTravels.Add(travel);
            airportRepository.UpdateAirport(destinationairport);
            travel.Airplane = airplane;
            airplane.Travels.Add(travel);
            airplaneRepository.UpdateAirplane(airplane);
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
                SaledTicket = travel.Tickets.Where(t => t.IsSaled == true).Count(),
                Price = travel.Price,
                OriginCityName = travel.OriginAirport.City.Name,
                DestinationCityName = travel.DestinationAirport.City.Name,
                OriginAirportName = travel.OriginAirport.Name,
                DestinationAirportName = travel.DestinationAirport.Name,
                AgancyName = travel.Airplane.Agancy.Name,
                AirplaneName = travel.Airplane.Name,
                MovingTime = travel.MovingTime,
                ArrivingTime = travel.ArrivingTime,
                MovingDate = Convert.ToDateTime(travel.MovingDate).ToShamsi(),
                ArrivingDate = Convert.ToDateTime(travel.ArrivingDate).ToShamsi(),
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
                MovingTime = Convert.ToDateTime(travel.MovingTime),
                ArrivingTime = Convert.ToDateTime(travel.ArrivingTime),
                MovingDate = Convert.ToDateTime(travel.MovingDate),
                ArrivingDate = Convert.ToDateTime(travel.ArrivingDate),
                Class = travel.Class,
                Price = travel.Price,
                AgancyId = travel.Airplane.Agancy.Id,
                AirplaneId = travel.Airplane.Id,
                DestinationCityId = travel.DestinationAirport.City.Id,
                DestinationCountryId = travel.DestinationAirport.City.Country.Id,
                OriginCityId = travel.OriginAirport.City.Id,
                OriginCountryId = travel.OriginAirport.City.Country.Id
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
            string org = dto.OriginAirportId.ToString();
            string dest = dto.DestinationAirportId.ToString();
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
            if (travel.Airplane.Id != dto.AirplaneId)
            {
                var airplane = airplaneRepository.GetAirplaneById(dto.AirplaneId);
                travel.Airplane = airplane;
                airplane.Travels.Add(travel);
                airplaneRepository.UpdateAirplane(airplane);
            }
            travel.MaxCapacity = dto.MaxCapacity;
            travel.Price = dto.Price;
            travel.MovingTime = dto.MovingTime.ToShortTimeString();
            travel.ArrivingTime = dto.ArrivingTime.ToShortTimeString();
            travel.MovingDate = dto.MovingDate.ToShortDateString();
            travel.ArrivingDate = dto.ArrivingDate.ToShortDateString(); ;
            if (dto.OriginCountryId == dto.DestinationCountryId)
            {
                travel.Type = "Domestic";
            }
            else
            {
                travel.Type = "International";
            }
            travel.Class = dto.Class;
            travel.Code = (org + dest + Guid.NewGuid()).Substring(0, 10).ToUpper();
            return travel;
        }
        #endregion
    }
}
