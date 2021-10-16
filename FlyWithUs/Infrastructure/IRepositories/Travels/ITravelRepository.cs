using FlyWithUs.Hosted.Service.Models.Travels;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Travels
{
    public interface ITravelRepository
    {
        int Add(Travel travel);

        int Delete(int travelid);

        int Update(Travel travel);

        TravelView GetTravel(int travelid);

        Travel GetById(int travelid);

        IQueryable<TravelView> GetAll();
              
        int Save();
    }
}
