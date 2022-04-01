using FlyWithUs.Hosted.Service.Models.Airplanes;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Airplanes
{
    public interface IAirplaneRepository
    {
        int Add(Airplane airplane);

        int Update(Airplane airplane);

        int Delete(int airplaneId);

        Airplane GetById(int airplaneId);

        IQueryable<Airplane> GetAll();

        int Save();

        bool IsExist(string name, string brand, int maxCapacity, int agancyId);
    }
}
