using AutoMapper;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Airports;
using FlyWithUs.Hosted.Service.DTOs.Cities;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World;
using FlyWithUs.Hosted.Service.Models.World;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            bool result = false;
            int count = repository.Add(mapper.Map<City>(dto));
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public bool DeleteCity(int cityid)
        {
            bool result = false;
            int count = repository.Delete(cityid);
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

        public CityDTO GetCityById(int cityid)
        {
            return Map(repository.GetById(cityid));
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

        public CityUpdateDTO GetCityForUpdate(int cityid)
        {
            return mapper.Map<CityUpdateDTO>(repository.GetById(cityid));
        }

        public bool UpdateCity(CityUpdateDTO dto)
        {
            bool result = false;
            int count = repository.Update(mapper.Map<City>(dto));
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public bool IsCityExist(string name, int countryid)
        {
            return repository.IsExist(name, countryid);
        }

        public bool IsCityExist(string name, int countryid, int cityid)
        {
            bool result = false;
            var city = repository.GetById(cityid);
            if (repository.IsExist(name, countryid) == true)
            {
                if (city.Name == name && city.Country.Id == countryid)
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


        public List<SelectListItem> GetAllCityAsSelectList(int? countryid)
        {
            if (countryid != null)
            {
                return repository.GetAll().Where(c => c.Country.Id == countryid)
                .Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList();
            }
            else
            {
                return repository.GetAll()
                .Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList();
            }
        }

    }
}
