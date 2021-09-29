using FlyWithUs.Hosted.Service.Infrastructure.Context;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World;
using FlyWithUs.Hosted.Service.Models.World;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.Repositories.World
{
    public class CityRepository : ICityRepository
    {
        private readonly FlyWithUsContext context;

        public CityRepository(FlyWithUsContext context)
        {
            this.context = context;
        }

        public int Add(City city)
        {
            context.Cities.Add(city);
            return Save();
        }

        public int Delete(int cityid)
        {
            var city = GetById(cityid);
            city.IsDeleted = true;
            return Update(city);
        }

        public IQueryable<City> GetAll()
        {
            return context.Cities.Include(c => c.Country).Include(c => c.Airports);
        }

        public City GetById(int cityid)
        {
            return context.Cities
                .Include(c => c.Country)
                .Include(c => c.Airports)
                .Include(c => c.IncomingTravels)
                .Include(c => c.OutboundTravels)
                .AsNoTracking()
                .First(c => c.Id == cityid);
        }

        public bool IsExist(string name, int countryid)
        {
            return context.Cities.Include(c => c.Country).Any(c => c.Name == name && c.Country.Id == countryid);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public int Update(City city)
        {
            context.Cities.Update(city);
            return Save();
        }
    }
}
