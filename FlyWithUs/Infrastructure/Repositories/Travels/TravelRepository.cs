using FlyWithUs.Hosted.Service.Infrastructure.Context;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Travels;
using FlyWithUs.Hosted.Service.Models.Travels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.Repositories.Travels
{
    public class TravelRepository : ITravelRepository
    {
        private readonly FlyWithUsContext context;

        public TravelRepository(FlyWithUsContext context)
        {
            this.context = context;
        }

        public int Add(Travel travel)
        {
            context.Travels.Add(travel);
            return Save();
        }

        public int Delete(int travelid)
        {
            var travel = GetById(travelid);
            travel.IsDeleted = true;
            return Update(travel);
        }

        public IQueryable<TravelView> GetAll()
        {
            return context.TravelViews;
        }

        public Travel GetById(int travelid)
        {
            return context.Travels
                .Include(t => t.Airplane)
                .Include(t => t.Agancy)
                .Include(t => t.OriginAirport)
                .Include(t => t.DestinationAirport)
                .Include(t => t.OriginCountry)
                .Include(t => t.DestinationCountry)
                .Include(t => t.OriginCity)
                .Include(t => t.DestinationCity)
                .Include(t => t.Tickets)
                .IgnoreQueryFilters()
                .First(t => t.Id == travelid);
        }

        public TravelView GetViewById(int travelid)
        {
            return context.TravelViews.Find(travelid);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public int Update(Travel travel)
        {
            context.Travels.Update(travel);
            return Save();
        }


    }
}
