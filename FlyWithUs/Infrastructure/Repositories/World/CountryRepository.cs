using FlyWithUs.Hosted.Service.Infrastructure.Context;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World;
using FlyWithUs.Hosted.Service.Models.World;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.Repositories.World
{
    public class CountryRepository : ICountryRepository
    {
        private readonly FlyWithUsContext context;

        public CountryRepository(FlyWithUsContext context)
        {
            this.context = context;
        }

        public int Add(Country country)
        {
            context.Countries.Add(country);
            return Save();
        }

        public int Delete(int countryid)
        {
            var country = GetById(countryid);
            country.IsDeleted = true;
            return Update(country);
        }

        public IQueryable<Country> GetAll()
        {
            return context.Countries.Include(c => c.Cities);
        }

        public Country GetById(int countryid)
        {
            return context.Countries
                .Include(c => c.Cities)
                .Include(c => c.IncomingTravels)
                .Include(c => c.OutboundTravels)
                .AsNoTracking()
                .First(c => c.Id == countryid);
        }

        public bool IsExist(string englishname, string persianname, short phonecode)
        {
            return context.Countries.Any(c => c.EnglishName == englishname || c.PersianName == persianname || c.PhoneCode == phonecode);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public int Update(Country country)
        {
            context.Countries.Update(country);
            return Save();
        }
    }
}
