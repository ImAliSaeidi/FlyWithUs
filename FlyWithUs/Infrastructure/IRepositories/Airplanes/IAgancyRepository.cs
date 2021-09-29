using FlyWithUs.Hosted.Service.Models.Airplanes;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Airplanes
{
    public interface IAgancyRepository
    {
        int Add(Agancy agancy);

        int Delete(int id);

        int Update(Agancy agancy);

        Agancy GetById(int id);

        IQueryable<Agancy> GetAll();

        int Save();

        bool IsExist(string name);
    }
}
