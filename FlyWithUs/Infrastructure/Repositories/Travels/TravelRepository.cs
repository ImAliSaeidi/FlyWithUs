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

        public int Delete(int travelId)
        {
            var travel = GetById(travelId);
            travel.IsDeleted = true;
            return Update(travel);
        }

        public IQueryable<TravelView> GetAll()
        {
            return context.TravelViews.Where(t=>t.IsDeleted==false);
        }

        public Travel GetById(int travelId)
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
                .Where(t=>t.IsDeleted==false)
                .AsNoTracking()
                .First(t => t.Id == travelId);
        }

        public TravelView GetViewById(int travelId)
        {
            return context.TravelViews.Find(travelId);
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
