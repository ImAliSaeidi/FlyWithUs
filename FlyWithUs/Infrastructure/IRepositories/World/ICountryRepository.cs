using FlyWithUs.Hosted.Service.Models.World;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World
{
    public interface ICountryRepository
    {

        int Add(Country country);

        int Delete(int countryid);

        int Update(Country country);

        Country GetById(int countryid);

        IQueryable<Country> GetAll();

        bool IsExist(string englishname,string persianname);

        string GetCountryName(int nationalityid);

        int Save();
    }
}
