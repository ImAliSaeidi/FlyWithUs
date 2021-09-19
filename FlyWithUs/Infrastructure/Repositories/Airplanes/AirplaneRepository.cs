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
    public class AirplaneRepository : IAirplaneRepository
    {
        private readonly FlyWithUsContext context;

        public AirplaneRepository(FlyWithUsContext context)
        {
            this.context = context;
        }

        public int AddAirplane(Airplane airplane)
        {
            context.Airplanes.Add(airplane);
            Save();
            int id = airplane.Id;
            return id;
        }

        public int DeleteAirplane(int airplaneid)
        {
            var airplane = GetAirplaneById(airplaneid);
            airplane.IsDeleted = true;
            return UpdateAirplane(airplane);
        }

        public int UpdateAirplane(Airplane airplane)
        {
            context.Airplanes.Update(airplane);
            return Save();
        }

        public Airplane GetAirplaneById(int airplaneid)
        {
            return context.Airplanes.Include(a => a.Agancy).First(a => a.Id == airplaneid);
        }

        public List<Airplane> GetAllAirplane()
        {
            return context.Airplanes.Where(a => a.Agancy != null).Include(a => a.Agancy).ToList();
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public bool IsAirplaneExist(string name, string brand, int maxcapacity, int agancyid)
        {
            return context.Airplanes.Include(a => a.Agancy).Any(a =>
              a.Name == name
              && a.Brand == brand
              && a.MaxCapacity == maxcapacity
              && a.Agancy.Id == agancyid);
        }
    }
}
