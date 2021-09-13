﻿using FlyWithUs.Hosted.Service.Infrastructure.Context;
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
        public AirplaneRepository()
        {
            context = new FlyWithUsContext();
        }

        public int AddAirplane(Airplane airplane)
        {
            context.Airplanes.Add(airplane);
            return Save();
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
            return context.Airplanes.Find(airplaneid);
        }

        public List<Airplane> GetAllAirplane()
        {
            return context.Airplanes.Include(a => a.Agancy).ToList();
        }

        public List<Airplane> GetAllAirplaneByAgancy(int agancyid)
        {
            return context.Airplanes.Where(a => a.Agancy.Id == agancyid).ToList();
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
