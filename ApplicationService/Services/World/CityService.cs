using AutoMapper;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Airports;
using FlyWithUs.Hosted.Service.DTOs.Cities;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World;
using FlyWithUs.Hosted.Service.Models.World;
using System.Collections.Generic;
using System.Linq;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.World
{
    public class CityService : ICityService
    {
        private readonly ICityRepository repository;
        private readonly ICountryRepository countryRepository;
        private readonly IMapper mapper;

        public CityService(ICityRepository repository, IMapper mapper, ICountryRepository countryRepository)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.countryRepository = countryRepository;
        }

        public bool AddCity(CityAddDTO dto)
        {
            var result = false;
            if (IsCityExist(dto.PersianName, dto.CountryId) == false)
            {
                var city = mapper.Map<City>(dto);
                int count = repository.Add(city);
                if (count > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public bool DeleteCity(int cityId)
        {
            bool result = false;
            int count = repository.Delete(cityId);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public GridResultDTO<CityDTO> GetAllCity(int skip, int take)
        {
            var dtos = mapper.Map<List<CityDTO>>(repository.GetAll().Skip(skip).Take(take).ToList());
            var count = repository.GetAll().Count();
            foreach (var dto in dtos)
            {
                dto.CountryName = countryRepository.GetById(dto.CountryId).PersianName;
            }

            return new GridResultDTO<CityDTO>(count, dtos);
        }

        public CityDTO GetCityById(int cityId)
        {
            return Map(repository.GetById(cityId));
        }

        private CityDTO Map(City city)
        {
            CityDTO dto = mapper.Map<CityDTO>(city);
            foreach (var item in city.Airports)
            {
                dto.AirportDTOs.Add(mapper.Map<AirportDTO>(item));
            }
            return dto;
        }

        public bool UpdateCity(CityUpdateDTO dto)
        {
            bool result = false;
            if (IsCityExist(dto.PersianName, dto.CountryId, dto.Id) == false)
            {
                var city = mapper.Map<City>(dto);
                int count = repository.Update(city);
                if (count > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public bool IsCityExist(string persianName, int countryId)
        {
            return repository.IsExist(persianName, countryId);
        }

        public bool IsCityExist(string persianName, int countryId, int cityId)
        {
            bool result = false;
            var city = repository.GetById(cityId);
            if (repository.IsExist(persianName, countryId) == true)
            {
                if (city.PersianName == persianName && city.Country.Id == countryId)
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
    }
}
