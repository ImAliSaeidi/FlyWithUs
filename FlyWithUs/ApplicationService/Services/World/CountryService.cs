using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using FlyWithUs.Hosted.Service.DTOs.Airports;
using FlyWithUs.Hosted.Service.DTOs.Cities;
using FlyWithUs.Hosted.Service.DTOs.Countries;
using FlyWithUs.Hosted.Service.Infrastructure.Repositories.World;
using FlyWithUs.Hosted.Service.Models.World;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.World
{
    public class CountryService : ICountryService
    {
        private readonly CountryRepository repository;
        private readonly CityRepository cityRepository;
        public CountryService()
        {
            repository = new CountryRepository();
            cityRepository = new CityRepository();
        }

        #region Add Country
        public bool AddCountry(CountryAddDTO dto)
        {
            bool result = false;
            int count = repository.AddCountry(Map(dto));
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        private Country Map(CountryAddDTO dto)
        {
            return new Country
            {
                ISO2 = dto.EnglishName.Substring(0, 2).ToUpper(),
                Name = dto.EnglishName.ToUpper(),
                NiceName = dto.NiceName,
                ISO3 = dto.EnglishName.Substring(0, 3).ToUpper(),
                NumCode = dto.NumCode,
                PhoneCode = dto.PhoneCode
            };
        }
        #endregion


        #region Delete Country
        public bool DeleteCountry(int countryid)
        {
            bool result = false;
            int count = repository.DeleteCountry(countryid);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }
        #endregion


        #region Country As Select List
        public List<SelectListItem> GetAllCountryAsSelectList()
        {
            return repository.GetAllCountry()
                .Select(c => new SelectListItem()
                {
                    Text = c.NiceName,
                    Value = c.Id.ToString()
                }).ToList();
        }
        #endregion


        #region Get Country
        public CountryDTO GetCountryById(int countryid)
        {
            return Map(repository.GetCountryById(countryid));
        }

        public List<CountryDTO> GetAllCountry()
        {
            List<CountryDTO> dtos = new();
            List<Country> countries = repository.GetAllCountry();
            foreach (var item in countries)
            {
                dtos.Add(Map(item));
            }
            return dtos;
        }

        private CountryDTO Map(Country country)
        {
            CountryDTO dto = new CountryDTO();
            dto.Id = country.Id;
            dto.NiceName = country.NiceName;
            dto.NumCode = country.NumCode;
            dto.PhoneCode = country.PhoneCode;
            dto.CityDTOs = new List<CityDTO>();
            dto.AirportDTOs = new List<AirportDTO>();
            List<City> cities = cityRepository.GetAllCity().Where(c => c.Country.Id == country.Id).ToList();
            foreach (var city in cities)
            {
                dto.CityDTOs.Add(Map(city));
                foreach (var airport in city.Airports)
                {
                    dto.AirportDTOs.Add(Map(airport));
                }
            }

            return dto;
        }

        private CityDTO Map(City city)
        {
            return new CityDTO
            {
                Id = city.Id,
                Name = city.Name
            };
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


        #region Validation
        public bool IsExistCountry(string name, short numcode, short phonecode, int? countryid)
        {
            if (countryid != null)
            {
                bool result = false;
                var country = repository.GetCountryById(countryid.Value);
                if (repository.IsExistCountry(name, numcode, phonecode) == true)
                {
                    if (country.NiceName == name && country.NumCode == numcode && country.PhoneCode == phonecode)
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
                return repository.IsExistCountry(name, numcode, phonecode);
            }
        }
        #endregion


        #region Update Country
        public CountryUpdateDTO GetCountryForUpdate(int countryid)
        {
            var country = repository.GetCountryById(countryid);
            var dto = new CountryUpdateDTO
            {
                Id = country.Id,
                NiceName = country.NiceName,
                EnglishName = country.Name,
                NumCode = country.NumCode,
                PhoneCode = country.PhoneCode
            };
            return dto;
        }
        public bool UpdateCountry(CountryUpdateDTO dto)
        {
            bool result = false;
            int count = repository.UpdateCountry(Map(dto));
            if (count > 0)
            {
                result = true;
            }
            return result;
        }
        private Country Map(CountryUpdateDTO dto)
        {
            var country = repository.GetCountryById(dto.Id);
            country.ISO2 = dto.EnglishName.Substring(0, 2).ToUpper();
            country.Name = dto.EnglishName.ToUpper();
            country.NiceName = dto.NiceName;
            country.ISO3 = dto.EnglishName.Substring(0, 3).ToUpper();
            country.NumCode = dto.NumCode;
            country.PhoneCode = dto.PhoneCode;
            return country;
        }
        #endregion

    }
}
