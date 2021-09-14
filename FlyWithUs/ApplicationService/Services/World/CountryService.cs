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
                ISO2 = dto.NiceName.Substring(0, 2).ToUpper(),
                Name = dto.NiceName.ToUpper(),
                NiceName = dto.NiceName,
                ISO3 = dto.NiceName.Substring(0, 3).ToUpper(),
                NumCode = dto.NumCode,
                PhoneCode = dto.PhoneCode
            };
        }

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

        public List<SelectListItem> GetAllCountryForAddUser()
        {
            return repository.GetAllCountry()
                .Select(c => new SelectListItem()
                {
                    Text = c.NiceName,
                    Value = c.Id.ToString()
                }).ToList();
        }

        public CountryDTO GetCountryById(int countryid)
        {
            return Map(repository.GetCountryById(countryid));
        }

        public bool IsExistCountry(string name, short numcode, short phonecode, int? countryid)
        {
            if (countryid != null)
            {
                bool result = false;
                var country = repository.GetCountryById(countryid.Value);
                if (repository.IsExistCountry(name, numcode, phonecode) == true)
                {
                    if (country.Name == name && country.NumCode == numcode && country.PhoneCode == phonecode)
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
            country.ISO2 = dto.NiceName.Substring(0, 2).ToUpper();
            country.Name = dto.NiceName.ToUpper();
            country.NiceName = dto.NiceName;
            country.ISO3 = dto.NiceName.Substring(0, 3).ToUpper();
            country.NumCode = dto.NumCode;
            country.PhoneCode = dto.PhoneCode;
            return country;
        }
        private CountryDTO Map(Country country)
        {
            return new CountryDTO
            {
                Id = country.Id,
                NiceName = country.NiceName
            };
        }

        public CountryUpdateDTO GetCountryForUpdate(int countryid)
        {
            var country = repository.GetCountryById(countryid);
            var dto = new CountryUpdateDTO();
            dto.Id = country.Id;
            dto.NiceName = country.NiceName;
            dto.NumCode = country.NumCode;
            dto.PhoneCode = country.PhoneCode;
            return dto;
        }

    }
}
