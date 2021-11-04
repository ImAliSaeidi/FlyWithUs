using FlyWithUs.Hosted.Service.Models.World;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World
{
    public interface ICityRepository
    {
        int Add(City city);

        int Delete(int cityId);

        int Update(City city);

        City GetById(int cityId);

        IQueryable<City> GetAll();

        bool IsExist(string persianName, int countryId);

        int Save();

        IQueryable<PopularDestinationView> GetPopularDestinations();
    }
}
