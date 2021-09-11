using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using FlyWithUs.Hosted.Service.DTOs.Countries;
using FlyWithUs.Hosted.Service.Infrastructure.Repositories.World;
using FlyWithUs.Hosted.Service.Models.World;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public List<SelectListItem> GetAllCountryForAddUser()
        {
            return repository.GetAllCountry()
                .Select(c => new SelectListItem()
                {
                    Text = c.NiceName,
                    Value = c.Id.ToString()
                }).ToList();
        }

        private CountryDTO Map(Country country)
        {
            return new CountryDTO
            {
                Id = country.Id,
                NiceName = country.NiceName
            };
        }
    }
}
