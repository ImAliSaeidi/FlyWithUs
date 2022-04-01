using AutoMapper;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Airports;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World;
using FlyWithUs.Hosted.Service.Models.World;
using System.Collections.Generic;
using System.Linq;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.World
{
    public class AirportService : IAirportService
    {
        private readonly IAirportRepository repository;
        private readonly IMapper mapper;

        public AirportService(IAirportRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public bool AddAirport(AirportAddDTO dto)
        {
            bool result = false;
            if (IsAirportExist(dto.PersianName, dto.CityId) == false)
            {
                int count = repository.Add(mapper.Map<Airport>(dto));
                if (count > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public bool DeleteAirport(int airportId)
        {
            bool result = false;
            int count = repository.Delete(airportId);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public AirportDTO GetAirportById(int airportId)
        {
            var airport = repository.GetById(airportId);
            var dto = mapper.Map<AirportDTO>(airport);
            dto.CountryId = airport.City.CountryId;
            return dto;
        }
                
        public GridResultDTO<AirportDTO> GetAllAirport(int skip, int take)
        {
            var airports = repository.GetAll().Skip(skip).Take(take).ToList();
            var dtos = new List<AirportDTO>();
            foreach (var item in airports)
            {
                var dto = mapper.Map<AirportDTO>(item);
                dto.CityName = item.City.PersianName;
                dtos.Add(dto);
            }
            var count = repository.GetAll().Count();
            return new GridResultDTO<AirportDTO>(count, dtos);
        }

        public bool IsAirportExist(string name, int cityId)
        {
            return repository.IsExist(name, cityId);
        }

        public bool IsAirportExist(string name, int cityId, int airportId)
        {
            bool result = false;
            var airport = repository.GetById(airportId);
            if (repository.IsExist(name, cityId) == true)
            {
                if (airport.PersianName == name && airport.City.Id == cityId)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            return result;
        }

        public bool UpdateAirport(AirportUpdateDTO dto)
        {
            bool result = false;
            if (IsAirportExist(dto.PersianName, dto.CityId, dto.Id) == false)
            {
                int count = repository.Update(mapper.Map<Airport>(dto));
                if (count > 0)
                {
                    result = true;
                }
            }
            return result;
        }

    }
}
