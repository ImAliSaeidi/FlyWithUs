using AutoMapper;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Airports;
using FlyWithUs.Hosted.Service.DTOs.Cities;
using FlyWithUs.Hosted.Service.DTOs.Countries;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World;
using FlyWithUs.Hosted.Service.Models.World;
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
            if (IsExistCountry(dto.EnglishName, dto.PersianName) == false)
            {
                int count = repository.Add(mapper.Map<Country>(dto));
                if (count > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public bool DeleteCountry(int countryId)
        {
            bool result = false;
            int count = repository.Delete(countryId);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }
              
        public CountryDTO GetCountryById(int countryId)
        {
            return Map(repository.GetById(countryId));
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

        public bool IsExistCountry(string englishName, string persianName)
        {
            return repository.IsExist(englishName, persianName);
        }

        public bool IsExistCountry(string englishName, string persianName, int countryId)
        {
            bool result = false;
            var country = repository.GetById(countryId);
            if (repository.IsExist(englishName, persianName) == true)
            {
                if (country.EnglishName == englishName && country.PersianName == persianName)
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
                
        public bool UpdateCountry(CountryUpdateDTO dto)
        {
            bool result = false;
            if (IsExistCountry(dto.EnglishName, dto.PersianName, dto.Id) == false)
            {
                int count = repository.Update(mapper.Map<Country>(dto));
                if (count > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public List<CountryListDTO> GetAllCountryForAPI()
        {
            return mapper.Map<List<CountryListDTO>>(repository.GetAll().ToList());
        }

        public List<CountryDTO> GetAllWithoutPaging()
        {
            var countries = repository.GetAll().ToList();
            var dtos = new List<CountryDTO>();
            foreach (var country in countries)
            {
                var dto = mapper.Map<CountryDTO>(country);
                foreach (var city in country.Cities)
                {
                    dto.CityDTOs.Add(Map(city));
                    foreach (var airport in city.Airports)
                    {
                        dto.AirportDTOs.Add(mapper.Map<AirportDTO>(airport));
                    }
                }
                dtos.Add(dto);
            }
            return dtos;
        }

        private CityDTO Map(City city)
        {
            var dto = mapper.Map<CityDTO>(city);
            foreach (var airport in city.Airports)
            {
                dto.AirportDTOs.Add(mapper.Map<AirportDTO>(airport));
            }
            return dto;
        }
    }
}
