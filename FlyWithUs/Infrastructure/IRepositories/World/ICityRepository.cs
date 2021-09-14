using FlyWithUs.Hosted.Service.Models.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World
{
    public interface ICityRepository
    {
        int AddCity(City city);

        int DeleteCity(int cityid);

        int UpdateCity(City city);

        City GetCityById(int cityid);

        List<City> GetAllCity();

        bool IsCityExist(string name, int countryid);

        int Save();
    }
}
