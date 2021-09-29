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

        public int Delete(int airportid)
        {
            var airport = GetById(airportid);
            airport.IsDeleted = true;
            return Update(airport);
        }

        public Airport GetById(int airportid)
        {
            return context.Airports.Include(a => a.City).AsNoTracking().First(a => a.Id == airportid);
        }

        public IQueryable<Airport> GetAll()
        {
            return context.Airports.Include(a => a.City);
        }

        public bool IsExist(string name, int cityid)
        {
            return context.Airports.Include(a => a.City).Any(a => a.Name == name && a.City.Id == cityid);
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
