using FlyWithUs.Hosted.Service.Infrastructure.Context;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World;
using FlyWithUs.Hosted.Service.Models.World;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Infrastructure.Repositories.World
{
    public class CityRepository : ICityRepository
    {
        private readonly FlyWithUsContext context;
        public CityRepository()
        {
            context = new FlyWithUsContext();
        }

        public int AddCity(City city)
        {
            context.Cities.Add(city);
            Save();
            return city.Id;
        }

        public int DeleteCity(int cityid)
        {
            var city = GetCityById(cityid);
            city.IsDeleted = true;
            return UpdateCity(city);
        }

        public List<City> GetAllCity()
        {
            return context.Cities.ToList();
        }

        public List<City> GetCityByCountryId(int countryid)
        {
            return context.Cities.Include(c => c.Country).Where(c => c.Country.Id == countryid).ToList();
        }

        public City GetCityById(int cityid)
        {
            return context.Cities.Find(cityid);
        }

        public bool IsCityExist(string name, int countryid)
        {
            return context.Cities.Include(c => c.Country).Any(c => c.Name == name && c.Country.Id == countryid);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public int UpdateCity(City city)
        {
            context.Cities.Update(city);
            return Save();
        }
    }
}
