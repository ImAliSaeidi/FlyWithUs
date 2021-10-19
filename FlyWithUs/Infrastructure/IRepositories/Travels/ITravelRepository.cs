using FlyWithUs.Hosted.Service.Models.Travels;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Travels
{
    public interface ITravelRepository
    {
        int Add(Travel travel);

        int Delete(int travelid);

        int Update(Travel travel);
               
        Travel GetById(int travelid);

        TravelView GetViewById(int travelid);

        IQueryable<TravelView> GetAll();

        int Save();
    }
}
