using FlyWithUs.Hosted.Service.Infrastructure.Context;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World;
using FlyWithUs.Hosted.Service.Models.World;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Infrastructure.Repositories.World
{
    public class CountryRepository : ICountryRepository
    {
        private readonly FlyWithUsContext context;
        public CountryRepository()
        {
            context = new FlyWithUsContext();
        }

        public int AddCountry(Country country)
        {
            context.Countries.Add(country);
            return Save();
        }

        public int DeleteCountry(int countryid)
        {
            var country = GetCountryById(countryid);
            country.IsDeleted = true;
            return UpdateCountry(country);
        }

        public List<Country> GetAllCountry()
        {
            return context.Countries.ToList();
        }

        public Country GetCountryById(int countryid)
        {
            return context.Countries.AsNoTracking().Include(c => c.Cities).First(c => c.Id == countryid);
        }

        public bool IsExistCountry(string name, short numcode, short phonecode)
        {
            return context.Countries.Any(c => c.NiceName == name && c.NumCode == numcode && c.PhoneCode == phonecode);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public int UpdateCountry(Country country)
        {
            context.Countries.Update(country);
            return Save();
        }
    }
}
