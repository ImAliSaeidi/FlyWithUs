using FlyWithUs.Hosted.Service.Models.World;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World
{
    public interface IAirportRepository
    {
        int Add(Airport airport);

        int Update(Airport airport);

        int Delete(int airportId);

        Airport GetById(int airportId);

        IQueryable<Airport> GetAll();

        bool IsExist(string name, int cityId);

        int Save();
    }
}
