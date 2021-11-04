using FlyWithUs.Hosted.Service.Infrastructure.Context;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Airplanes;
using FlyWithUs.Hosted.Service.Models.Airplanes;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.Repositories.Airplanes
{
    public class AirplaneRepository : IAirplaneRepository
    {
        private readonly FlyWithUsContext context;

        public AirplaneRepository(FlyWithUsContext context)
        {
            this.context = context;
        }

        public int Add(Airplane airplane)
        {
            context.Airplanes.Add(airplane);
            return Save();
        }

        public int Delete(int airplaneId)
        {
            var airplane = GetById(airplaneId);
            airplane.IsDeleted = true;
            return Update(airplane);
        }

        public int Update(Airplane airplane)
        {
            context.Airplanes.Update(airplane);
            return Save();
        }

        public Airplane GetById(int airplaneId)
        {
            return context.Airplanes
                .Include(a => a.Agancy)
                .AsNoTracking()
                .IgnoreQueryFilters()
                .Where(a => a.IsDeleted == false)
                .First(a => a.Id == airplaneId);
        }

        public IQueryable<Airplane> GetAll()
        {
            return context.Airplanes.Include(a => a.Agancy);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public bool IsExist(string name, string brand, int maxCapacity, int agancyId)
        {
            return context.Airplanes.Include(a => a.Agancy).Any(a =>
              a.Name == name
              && a.Brand == brand
              && a.MaxCapacity == maxCapacity
              && a.Agancy.Id == agancyId);
        }
    }
}
