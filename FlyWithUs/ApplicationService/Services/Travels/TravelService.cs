using AutoMapper;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.Travels;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Travels;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Travels;
using FlyWithUs.Hosted.Service.Models.Travels;
using FlyWithUs.Hosted.Service.Tools.Convertors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace FlyWithUs.Hosted.Service.ApplicationService.Services.Travels
{
    public class TravelService : ITravelService
    {
        private readonly ITravelRepository repository;
        private readonly IMapper mapper;

        public TravelService(ITravelRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
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

        public GridResultDTO<TravelViewDTO> GetAllTravel(int skip, int take)
        {
            var dtos = new List<TravelViewDTO>();
            var travels = repository.GetAll().Skip(skip).Take(take).ToList();
            foreach (var item in travels)
            {
                var dto = mapper.Map<TravelViewDTO>(item);
                dto.MovingDate = item.MovingDate.ToShamsi();
                dto.MovingTime = item.MovingTime.ToString("HH:mm");
                dto.ArrivingTime = item.ArrivingTime.ToString("HH:mm");
                dto.Price = item.Price.ToString("N0");
                dtos.Add(dto);
            }
            var count = repository.GetAll().Count();
            return new GridResultDTO<TravelViewDTO>(count, dtos);
        }

        public TravelDTO GetTravelById(int travelid)
        {
            var travel = repository.GetById(travelid);
            var dto = mapper.Map<TravelDTO>(repository.GetById(travelid));
            dto.AgancyName = travel.Agancy.Name;
            dto.OriginCityName = travel.OriginCity.PersianName;
            dto.DestinationCityName = travel.DestinationCity.PersianName;
            dto.SoldTicket = travel.Tickets.Where(t => t.IsDeleted == false).ToList().Count;
            return dto;
        }

        public TravelUpdateDTO GetTravelForUpdate(int travelid)
        {
            var dto = mapper.Map<TravelUpdateDTO>(repository.GetById(travelid));
            dto.AgancyId = repository.GetById(travelid).Airplane.Agancy.Id;
            return dto;
        }

        public TravelViewDTO GetTravelViewById(int travelid)
        {
            var travel = repository.GetViewById(travelid);
            var dto = mapper.Map<TravelViewDTO>(travel);
            dto.MovingDate = travel.MovingDate.ToShamsi();
            dto.ArrivingDate = travel.ArrivingDate.ToShamsi();
            dto.MovingTime = travel.MovingTime.ToString("HH:mm");
            dto.ArrivingTime = travel.ArrivingTime.ToString("HH:mm");
            dto.Price = travel.Price.ToString("N0");
            return dto;
        }

        public GridResultDTO<TravelViewDTO> SearchTravel(int skip, int take, TravelSearchDTO dto)
        {
            var dtos = new List<TravelViewDTO>();
            var travels = new List<TravelView>();
            if (dto.OrderBy == "MovingTime" || dto.OrderBy == null)
            {
                travels = repository
                  .GetAll()
                  .Where(x =>
                  x.OriginCityName.Contains(dto.Origin) &&
                  x.DestinationCityName.Contains(dto.Destination) &&
                  x.MovingDate == dto.MovingDate)
                  .Skip(skip)
                  .Take(take)
                  .OrderBy(x => x.MovingTime)
                  .ToList();
            }
            if (dto.OrderBy == "PriceD")
            {
                travels = repository
                  .GetAll()
                  .Where(x =>
                  x.OriginCityName.Contains(dto.Origin) &&
                  x.DestinationCityName.Contains(dto.Destination) &&
                  x.MovingDate == dto.MovingDate)
                  .Skip(skip)
                  .Take(take)
                  .OrderByDescending(x => x.Price)
                  .ToList();
            }
            if (dto.OrderBy == "PriceA")
            {
                travels = repository
                  .GetAll()
                  .Where(x =>
                  x.OriginCityName.Contains(dto.Origin) &&
                  x.DestinationCityName.Contains(dto.Destination) &&
                  x.MovingDate == dto.MovingDate)
                  .Skip(skip)
                  .Take(take)
                  .OrderBy(x => x.Price)
                  .ToList();
            }
            foreach (var item in travels)
            {
                var tdto = mapper.Map<TravelViewDTO>(item);
                tdto.MovingDate = item.MovingDate.ToShamsi();
                tdto.ArrivingDate = item.ArrivingDate.ToShamsi();
                tdto.MovingTime = item.MovingTime.ToString("HH:mm");
                tdto.ArrivingTime = item.ArrivingTime.ToString("HH:mm");
                tdto.Price = item.Price.ToString("N0");
                dtos.Add(tdto);
            }

            var count = repository
                 .GetAll()
                 .Where(x =>
                  x.OriginCityName.Contains(dto.Origin) &&
                  x.DestinationCityName.Contains(dto.Destination) &&
                  x.MovingDate == dto.MovingDate)
                 .ToList().Count;
            return new GridResultDTO<TravelViewDTO>(count, dtos);
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
