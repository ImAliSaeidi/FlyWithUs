using FlyWithUs.Hosted.Service.Models.World;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World
{
    public interface IAirportRepository
    {
        int Add(Airport airport);

        int Update(Airport airport);

        int Delete(int airportid);

        Airport GetById(int airportid);

        IQueryable<Airport> GetAll();

        bool IsExist(string name, int cityid);

        int Save();
    }
}
