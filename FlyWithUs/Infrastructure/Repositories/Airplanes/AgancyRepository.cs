using FlyWithUs.Hosted.Service.Infrastructure.Context;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Airplanes;
using FlyWithUs.Hosted.Service.Models.Airplanes;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.Repositories.Airplanes
{
    public class AgancyRepository : IAgancyRepository
    {
        private readonly FlyWithUsContext context;

        public AgancyRepository(FlyWithUsContext context)
        {
            this.context = context;
        }

        public int Add(Agancy agancy)
        {
            context.Agancies.Add(agancy);
            return Save();
        }

        public int Delete(int agancyid)
        {
            var agancy = GetById(agancyid);
            agancy.IsDeleted = true;
            return Update(agancy);
        }

        public Agancy GetById(int agancyid)
        {
            return context.Agancies.Include(a => a.Airplanes).AsNoTracking().First(a => a.Id == agancyid);
        }

        public IQueryable<Agancy> GetAll()
        {
            return context.Agancies.Include(a => a.Airplanes);
        }

        public bool IsExist(string name)
        {
            return context.Agancies.Any(a => a.Name == name);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public int Update(Agancy agancy)
        {
            context.Agancies.Update(agancy);
            return Save();
        }
    }
}
