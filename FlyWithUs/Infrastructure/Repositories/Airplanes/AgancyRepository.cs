using FlyWithUs.Hosted.Service.Infrastructure.Context;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Airplanes;
using FlyWithUs.Hosted.Service.Models.Airplanes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Infrastructure.Repositories.Airplanes
{
    public class AgancyRepository : IAgancyRepository
    {
        private readonly FlyWithUsContext context;
        public AgancyRepository()
        {
            context = new FlyWithUsContext();
        }

        public int AddAgancy(Agancy agancy)
        {
            context.Agancies.Add(agancy);
            return Save();
        }

        public int DeleteAgancy(int agancyid)
        {
            var agancy = GetAgancyById(agancyid);
            agancy.IsDeleted = true;
            return UpdateAgancy(agancy);
        }

        public Agancy GetAgancyById(int agancyid)
        {
            return context.Agancies.Include(a => a.Airplanes).First(a => a.Id == agancyid);
        }

        public List<Agancy> GetAllAgancy()
        {
            return context.Agancies.Include(a => a.Airplanes).ToList();
        }

        public bool IsAgancyExist(string name)
        {
            return context.Agancies.Any(a => a.Name == name);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public int UpdateAgancy(Agancy agancy)
        {
            context.Agancies.Update(agancy);
            return Save();
        }
    }
}
