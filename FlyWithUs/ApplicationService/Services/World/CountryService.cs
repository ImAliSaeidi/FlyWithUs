using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using FlyWithUs.Hosted.Service.DTOs.Countries;
using FlyWithUs.Hosted.Service.Infrastructure.Repositories.World;
using FlyWithUs.Hosted.Service.Models.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.World
{
    public class CountryService : ICountryService
    {
        private readonly CountryRepository repository;
        public CountryService()
        {
            repository = new CountryRepository();
        }

        public List<CountryDTO> GetAllCountry()
        {
            List<CountryDTO> dtos = new List<CountryDTO>();
            List<Country> countries = repository.GetAllCountry();
            foreach (var item in countries)
            {
                dtos.Add(Map(item));
            }
            return dtos;
        }

        private CountryDTO Map(Country country)
        {
            return new CountryDTO
            {
                Id=country.Id,
                NiceName = country.NiceName
            };
        }
    }
}
