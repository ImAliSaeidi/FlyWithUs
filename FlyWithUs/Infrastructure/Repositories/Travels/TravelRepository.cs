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
        public TravelRepository()
        {
            context = new FlyWithUsContext();
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
                .Include(t => t.OriginCity)
                .Include(t => t.DestinationCity)
                .Include(t => t.TravelDetails)
                .Include(t => t.MultiPartTravels)
                .ToList();
        }

        public Travel GetTravelById(int travelid)
        {
            return context.Travels
                .Include(t => t.OriginCity)
                .Include(t => t.DestinationCity)
                .Include(t => t.TravelDetails)
                .Include(t => t.MultiPartTravels)
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
