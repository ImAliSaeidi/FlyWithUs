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

        public int Delete(int countryId)
        {
            var country = GetById(countryId);
            country.IsDeleted = true;
            return Update(country);
        }

        public IQueryable<Country> GetAll()
        {
            return context.Countries
                .Include(c => c.Cities)
                .ThenInclude(ct => ct.Airports);
        }

        public Country GetById(int countryId)
        {
            return context.Countries
                .Include(c => c.Cities)
                .Include(c => c.IncomingTravels)
                .Include(c => c.OutboundTravels)
                .AsNoTracking()
                .First(c => c.Id == countryId);
        }

        public bool IsExist(string englishName, string persianName)
        {
            return context.Countries.Any(c => c.EnglishName == englishName && c.PersianName == persianName);
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

        public string GetCountryName(int nationalityId)
        {
            return context.Countries.Find(nationalityId).PersianName;
        }
    }
}
