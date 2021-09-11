using FlyWithUs.Hosted.Service.Models.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World
{
  public  interface ICountryRepository
    {
        List<Country> GetAllCountry();
    }
}
