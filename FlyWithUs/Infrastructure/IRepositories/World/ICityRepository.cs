using FlyWithUs.Hosted.Service.Models.World;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World
{
    public interface ICityRepository
    {
        int Add(City city);

        int Delete(int cityid);

        int Update(City city);

        City GetById(int cityid);

        IQueryable<City> GetAll();

        bool IsExist(string persianName, int countryid);

        int Save();

        IQueryable<PopularDestinationView> GetPopularDestinations();
    }
}
