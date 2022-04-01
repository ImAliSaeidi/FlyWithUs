using FlyWithUs.Hosted.Service.Infrastructure.Context;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World;
using FlyWithUs.Hosted.Service.Models.World;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.Repositories.World
{
    public class AirportRepository : IAirportRepository
    {
        private readonly FlyWithUsContext context;

        public AirportRepository(FlyWithUsContext context)
        {
            this.context = context;
        }

        public int Add(Airport airport)
        {
            context.Airports.Add(airport);
            return Save();
        }

        public int Delete(int airportId)
        {
            var airport = GetById(airportId);
            airport.IsDeleted = true;
            return Update(airport);
        }

        public Airport GetById(int airportId)
        {
            return context.Airports
                .Include(a => a.City)
                .AsNoTracking()
                .IgnoreQueryFilters()
                .Where(a => a.IsDeleted == false)
                .First(a => a.Id == airportId);
        }

        public IQueryable<Airport> GetAll()
        {
            return context.Airports.Include(a => a.City).IgnoreQueryFilters().Where(a => a.IsDeleted == false);
        }

        public bool IsExist(string name, int cityId)
        {
            return context.Airports.Include(a => a.City).Any(a => a.PersianName == name && a.City.Id == cityId);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public int Update(Airport airport)
        {
            context.Airports.Update(airport);
            return Save();
        }
    }
}
