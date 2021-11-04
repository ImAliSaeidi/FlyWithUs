using FlyWithUs.Hosted.Service.Models.World;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World
{
    public interface ICountryRepository
    {

        int Add(Country country);

        int Delete(int countryId);

        int Update(Country country);

        Country GetById(int countryId);

        IQueryable<Country> GetAll();

        bool IsExist(string englishName,string persianName);

        string GetCountryName(int nationalityId);

        int Save();
    }
}
