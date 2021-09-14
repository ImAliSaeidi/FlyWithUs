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
    public class AirportRepository : IAirportRepository
    {
        private readonly FlyWithUsContext context;
        public AirportRepository()
        {
            context = new FlyWithUsContext();
        }

        public int AddAirport(Airport airport)
        {
            context.Airports.Add(airport);
            Save();
            return airport.Id;
        }

        public int DeleteAirport(int airportid)
        {
            var airport = GetAirportById(airportid);
            airport.IsDeleted = true;
            return UpdateAirport(airport);
        }

        public Airport GetAirportById(int airportid)
        {
            return context.Airports.Include(a => a.City).First(a => a.Id == airportid);
        }

        public List<Airport> GetAllAirport()
        {
            return context.Airports.Include(a => a.City).ToList();
        }

        public bool IsAirportExist(string name, int cityid)
        {
            return context.Airports.Include(a => a.City).Any(a => a.Name == name && a.City.Id == cityid);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public int UpdateAirport(Airport airport)
        {
            context.Airports.Update(airport);
            return Save();
        }
    }
}
