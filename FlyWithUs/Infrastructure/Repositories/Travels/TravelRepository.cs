using FlyWithUs.Hosted.Service.Infrastructure.Context;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Travels;
using FlyWithUs.Hosted.Service.Models.Travels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Infrastructure.Repositories.Travels
{
    public class TravelRepository : ITravelRepository
    {
        private readonly FlyWithUsContext context;

        public TravelRepository(FlyWithUsContext context)
        {
            this.context = context;
        }

        public int AddTravel(Travel travel)
        {
            context.Travels.Add(travel);
            Save();
            return travel.Id;
        }

        public int DeleteTravel(int travelid)
        {
            var travel = GetTravelById(travelid);
            travel.IsDeleted = true;
            return UpdateTravel(travel);
        }

        public List<Travel> GetAllTravel()
        {
            return context.Travels
                .Include(t => t.Airplane)
                .Include(t => t.Airplane.Agancy)
                .Include(t => t.OriginAirport)
                .Include(t => t.OriginAirport.City)
                .Include(t => t.OriginAirport.City.Country)
                .Include(t => t.DestinationAirport)
                .Include(t => t.DestinationAirport.City)
                .Include(t => t.DestinationAirport.City.Country)
                .IgnoreQueryFilters()
                .ToList();
        }

        public Travel GetTravelById(int travelid)
        {
            return context.Travels
                .Include(t => t.Airplane)
                .Include(t => t.Airplane.Agancy)
                .Include(t => t.OriginAirport)
                .Include(t => t.OriginAirport.City)
                .Include(t => t.OriginAirport.City.Country)
                .Include(t => t.DestinationAirport)
                .Include(t => t.DestinationAirport.City)
                .Include(t => t.DestinationAirport.City.Country)
                .IgnoreQueryFilters()
                .First(t => t.Id == travelid);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public int UpdateTravel(Travel travel)
        {
            context.Travels.Update(travel);
            return Save();
        }
    }
}
