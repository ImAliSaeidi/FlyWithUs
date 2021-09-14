using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using FlyWithUs.Hosted.Service.DTOs.Cities;
using FlyWithUs.Hosted.Service.Infrastructure.Repositories.World;
using FlyWithUs.Hosted.Service.Models.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.World
{
    public class CityService : ICityService
    {
        private readonly CityRepository repository;
        private readonly CountryRepository countryRepository;
        public CityService()
        {
            repository = new CityRepository();
            countryRepository = new CountryRepository();
        }

        public bool AddCity(CityAddDTO dto)
        {
            bool result = false;
            int cityid = repository.AddCity(Map(dto));
            if (cityid > 0)
            {
                var city = repository.GetCityById(cityid);
                var country = countryRepository.GetCountryById(dto.CountryId);
                city.Country = country;
                repository.UpdateCity(city);
                result = true;
            }
            return result;
        }

        private City Map(CityAddDTO dto)
        {
            return new City
            {
                Name = dto.Name,
            };
        }

        public bool DeleteCity(int cityid)
        {
            bool result = false;
            int count = repository.DeleteCity(cityid);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public List<CityDTO> GetAllCity()
        {
            List<CityDTO> dtos = new List<CityDTO>();
            List<City> cities = repository.GetAllCity();
            foreach (var item in cities)
            {
                dtos.Add(Map(item));
            }
            return dtos;
        }

        public CityDTO GetCityById(int cityid)
        {
            return Map(repository.GetCityById(cityid));
        }

        private CityDTO Map(City city)
        {
            return new CityDTO
            {
                Id = city.Id,
                Name = city.Name,
                CountryName = countryRepository.GetCountryById(city.Country.Id).Name
            };
        }

        public CityUpdateDTO GetCityForUpdate(int cityid)
        {
            var city = repository.GetCityById(cityid);
            return new CityUpdateDTO
            {
                Id = city.Id,
                Name = city.Name,
                CountryId = city.Country.Id
            };
        }

        public bool UpdateCity(CityUpdateDTO dto)
        {
            bool result = false;
            int count = repository.UpdateCity(Map(dto));
            if (count > 0)
            {
                result = true;
            }
            return result;
        }
        private City Map(CityUpdateDTO dto)
        {
            var city = repository.GetCityById(dto.Id);
            var country = countryRepository.GetCountryById(dto.CountryId);
            city.Name = dto.Name;
            city.Country = country;
            return city;
        }
    }
}
