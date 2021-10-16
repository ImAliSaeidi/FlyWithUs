using AutoMapper;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.Travels;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Travels;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Tickets;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Travels;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Users;
using FlyWithUs.Hosted.Service.Models.Tickets;
using FlyWithUs.Hosted.Service.Models.Travels;
using System;
using System.Linq;


namespace FlyWithUs.Hosted.Service.ApplicationService.Services.Travels
{
    public class TravelService : ITravelService
    {
        private readonly ITravelRepository repository;
        private readonly ITicketRepository ticketRepository;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public TravelService(ITravelRepository repository, IMapper mapper, ITicketRepository ticketRepository, IUserRepository userRepository)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.ticketRepository = ticketRepository;
            this.userRepository = userRepository;
        }

        public bool AddTicket(int travelid, string userid)
        {
            bool result = false;
            string code = travelid.ToString() + Guid.NewGuid().ToString().Substring(0, 7).ToUpper();
            Ticket ticket = new Ticket(travelid, code);
            UserTicket userTicket = new UserTicket()
            {
                UserId = userid
            };
            ticket.UserTickets.Add(userTicket);
            int count = ticketRepository.AddTicket(ticket);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public bool AddTravel(TravelAddDTO dto)
        {
            bool result = false;
            dto.Code = dto.OriginAirportId.ToString() + dto.DestinationAirportId.ToString() + Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            if (dto.OriginCountryId != dto.DestinationCountryId)
            {
                dto.Type = "International";
            }
            else
            {
                dto.Type = "Domestic";
            }
            var travel = mapper.Map<Travel>(dto);
            int count = repository.Add(travel);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public bool DeleteTravel(int travelid)
        {
            bool result = false;
            int count = repository.Delete(travelid);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public GridResultDTO<TravelView> GetAllTravel(int skip, int take)
        {
            var travels = repository.GetAll().Skip(skip).Take(take).ToList();
            var count = repository.GetAll().Count();
            return new GridResultDTO<TravelView>(count, travels);
        }

        public TravelDTO GetTravelById(int travelid)
        {
            var travel = repository.GetById(travelid);
            var dto = mapper.Map<TravelDTO>(repository.GetById(travelid));
            dto.AgancyName = travel.Airplane.Agancy.Name;
            dto.OriginCityName = travel.OriginCity.Name;
            dto.DestinationCityName = travel.DestinationCity.Name;
            return dto;
        }

        public TravelUpdateDTO GetTravelForUpdate(int travelid)
        {
            var dto = mapper.Map<TravelUpdateDTO>(repository.GetById(travelid));
            dto.AgancyId = repository.GetById(travelid).Airplane.Agancy.Id;
            return dto;
        }

        public GridResultDTO<TravelView> SearchTravel(int skip, int take, TravelSearchDTO dto)
        {
            var travels = repository
                  .GetAll()
                  .Where(x =>
                  x.OriginCityName == dto.Origin &&
                  x.DestinationCityName == dto.Destination &&
                  x.MovingDate == dto.MovingDate)
                  .Skip(skip)
                  .Take(take)
                  .ToList();
            var count = repository
                  .GetAll()
                   .Where(x =>
                  x.OriginCityName == dto.Origin &&
                  x.DestinationCityName == dto.Destination &&
                  x.MovingDate == dto.MovingDate)
                  .ToList().Count;
            return new GridResultDTO<TravelView>(count, travels);
        }

        public bool UpdateTravel(TravelUpdateDTO dto)
        {
            bool result = false;
            dto.Code = dto.OriginAirportId.ToString() + dto.DestinationAirportId.ToString() + Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            if (dto.OriginCountryId != dto.DestinationCountryId)
            {
                dto.Type = "International";
            }
            else
            {
                dto.Type = "Domestic";
            }
            int count = repository.Update(mapper.Map<Travel>(dto));
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

    }
}
