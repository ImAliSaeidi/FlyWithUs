using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using FlyWithUs.Hosted.Service.DTOs.Airports;
using FlyWithUs.Hosted.Service.DTOs.Cities;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World;
using FlyWithUs.Hosted.Service.Infrastructure.Repositories.World;
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

        public CityService(ICityRepository repository, ICountryRepository countryRepository)
        {
            this.repository = repository;
            this.countryRepository = countryRepository;
        }


        #region Add City
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
        #endregion


        #region Delete City
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
        #endregion


        #region Get City
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
            CityDTO dto = new CityDTO();
            dto.Id = city.Id;
            dto.Name = city.Name;
            dto.CountryName = city.Country.NiceName;
            dto.AirportDTOs = new List<AirportDTO>();
            foreach (var item in city.Airports)
            {
                dto.AirportDTOs.Add(Map(item));
            }
            return dto;
        }

        private AirportDTO Map(Airport airport)
        {
            return new AirportDTO
            {
                Id = airport.Id,
                Name = airport.Name,
                EnglishName = airport.EnglishName,
                Code = airport.Code
            };
        }
        #endregion


        #region Update City
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
            if (city.Country.Id != dto.CountryId)
            {
                city.Country = country;
                country.Cities.Add(city);
                countryRepository.UpdateCountry(country);
            }
            return city;
        }
        #endregion


        #region Validation
        public bool IsCityExist(string name, int countryid, int? cityid)
        {
            if (cityid != null)
            {
                bool result = false;
                var city = repository.GetCityById(cityid.Value);
                if (repository.IsCityExist(name, countryid) == true)
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
            else
            {
                return repository.IsCityExist(name, countryid);
            }
        }
        #endregion


        #region City As Select List
        public List<SelectListItem> GetAllCityAsSelectList(int? countryid)
        {
            if (countryid != null)
            {
                return repository.GetAllCity().Where(c => c.Country.Id == countryid)
                .Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList();
            }
            else
            {
                return repository.GetAllCity()
                .Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList();
            }
        }
        #endregion
    }
}
