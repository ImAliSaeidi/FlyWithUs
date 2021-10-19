using AutoMapper;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Airports;
using FlyWithUs.Hosted.Service.DTOs.Cities;
using FlyWithUs.Hosted.Service.DTOs.Countries;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World;
using FlyWithUs.Hosted.Service.Models.World;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.World
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository repository;
        private readonly ICityRepository cityRepository;
        private readonly IMapper mapper;

        public CountryService(ICountryRepository repository, ICityRepository cityRepository, IMapper mapper)
        {
            this.repository = repository;
            this.cityRepository = cityRepository;
            this.mapper = mapper;
        }



        public bool AddCountry(CountryAddDTO dto)
        {
            bool result = false;
            int count = repository.Add(Map(dto));
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        private Country Map(CountryAddDTO dto)
        {
            Country country = mapper.Map<Country>(dto);
            country.ISO2 = dto.EnglishName.Substring(0, 2).ToUpper();
            country.EnglishName = dto.EnglishName.ToUpper();
            country.ISO3 = dto.EnglishName.Substring(0, 3).ToUpper();
            return country;
        }

        public bool DeleteCountry(int countryid)
        {
            bool result = false;
            int count = repository.Delete(countryid);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public List<SelectListItem> GetAllCountryAsSelectList()
        {
            var result = new List<SelectListItem>() {
                new SelectListItem
                {
                    Text="انتخاب کنید",
                    Value=""
                }};
            var countries = repository.GetAll()
                .Select(c => new SelectListItem()
                {
                    Text = c.PersianName,
                    Value = c.Id.ToString()
                }).ToList();
            result.AddRange(countries);
            return result;
        }

        public CountryDTO GetCountryById(int countryid)
        {
            return Map(repository.GetById(countryid));
        }

        public GridResultDTO<CountryDTO> GetAllCountry(int skip, int take)
        {
            var dtos = mapper.Map<List<CountryDTO>>(repository.GetAll().Skip(skip).Take(take).ToList());
            var count = repository.GetAll().Count();

            return new GridResultDTO<CountryDTO>(count, dtos);
        }

        private CountryDTO Map(Country country)
        {
            var dto = mapper.Map<CountryDTO>(country);
            var cities = cityRepository.GetAll().Where(c => c.Country.Id == country.Id).ToList();
            foreach (var city in cities)
            {
                dto.CityDTOs.Add(mapper.Map<CityDTO>(city));
                foreach (var airport in city.Airports)
                {
                    dto.AirportDTOs.Add(mapper.Map<AirportDTO>(airport));
                }
            }

            return dto;
        }

        public bool IsExistCountry(string englishname, string persianname, short phonecode)
        {
            return repository.IsExist(englishname, persianname, phonecode);
        }

        public bool IsExistCountry(string englishname, string persianname, short phonecode, int countryid)
        {
            bool result = false;
            var country = repository.GetById(countryid);
            if (repository.IsExist(englishname, persianname, phonecode) == true)
            {
                if (country.EnglishName == englishname && country.PersianName == persianname && country.PhoneCode == phonecode)
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

        public CountryUpdateDTO GetCountryForUpdate(int countryid)
        {
            return mapper.Map<CountryUpdateDTO>(repository.GetById(countryid));
        }

        public bool UpdateCountry(CountryUpdateDTO dto)
        {
            bool result = false;
            int count = repository.Update(Map(dto));
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        private Country Map(CountryUpdateDTO dto)
        {
            Country country = mapper.Map<Country>(dto);
            country.ISO2 = dto.EnglishName.Substring(0, 2).ToUpper();
            country.EnglishName = dto.EnglishName.ToUpper();
            country.ISO3 = dto.EnglishName.Substring(0, 3).ToUpper();
            return country;
        }

        public List<CountryListDTO> GetAllCountryForAPI()
        {
            return mapper.Map<List<CountryListDTO>>(repository.GetAll().ToList());
        }
    }
}
