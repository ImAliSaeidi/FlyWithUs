using FlyWithUs.Hosted.Service.Infrastructure.Context;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World;
using FlyWithUs.Hosted.Service.Models.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Infrastructure.Repositories.World
{
    public class CountryRepository : ICountryRepository
    {
        private readonly FlyWithUsContext context;
        public CountryRepository()
        {
            context = new FlyWithUsContext();
        }

        public List<Country> GetAllCountry()
        {
            return context.Countries.ToList();
        }
    }
}
