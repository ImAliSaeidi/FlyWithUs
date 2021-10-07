using AutoMapper;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.Airplanes;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.Travels;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Travels;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Airplanes;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Travels;
using FlyWithUs.Hosted.Service.Models.Travels;
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

        public GridResultDTO<TravelDTO> GetAllTravel(int skip, int take)
        {
            var dtos = new List<TravelDTO>();
            var travels = repository.GetAll().Skip(skip).Take(take).ToList();
            foreach (var travel in travels)
            {
                var dto = new TravelDTO();
                dto = mapper.Map<TravelDTO>(travel);
                dto.AgancyName = travel.Airplane.Agancy.Name;
                dtos.Add(dto);
            }
            var count = repository.GetAll().Count();
            return new GridResultDTO<TravelDTO>(count, dtos);
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
