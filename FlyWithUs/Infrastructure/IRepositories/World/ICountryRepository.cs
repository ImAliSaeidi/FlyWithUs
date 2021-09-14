using FlyWithUs.Hosted.Service.Models.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World
{
    public interface ICountryRepository
    {

        int AddCountry(Country country);

        int DeleteCountry(int countryid);

        int UpdateCountry(Country country);

        Country GetCountryById(int countryid);

        List<Country> GetAllCountry();

        bool IsExistCountry(string name,short numcode, short phonecode);

        int Save();
    }
}
