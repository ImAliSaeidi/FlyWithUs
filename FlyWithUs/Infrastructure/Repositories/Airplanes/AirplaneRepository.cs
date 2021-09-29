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

        public int Delete(int airplaneid)
        {
            var airplane = GetById(airplaneid);
            airplane.IsDeleted = true;
            return Update(airplane);
        }

        public int Update(Airplane airplane)
        {
            context.Airplanes.Update(airplane);
            return Save();
        }

        public Airplane GetById(int airplaneid)
        {
            return context.Airplanes.Include(a => a.Agancy).AsNoTracking().First(a => a.Id == airplaneid);
        }

        public IQueryable<Airplane> GetAll()
        {
            return context.Airplanes.Include(a => a.Agancy);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public bool IsExist(string name, string brand, int maxcapacity, int agancyid)
        {
            return context.Airplanes.Include(a => a.Agancy).Any(a =>
              a.Name == name
              && a.Brand == brand
              && a.MaxCapacity == maxcapacity
              && a.Agancy.Id == agancyid);
        }
    }
}
