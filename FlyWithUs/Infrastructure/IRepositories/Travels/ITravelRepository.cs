using FlyWithUs.Hosted.Service.Models.Travels;
using System.Collections.Generic;
using System.Linq;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Travels
{
    public interface ITravelRepository
    {
        int Add(Travel travel);

        int Delete(int travelId);

        int Update(Travel travel);

        Travel GetById(int travelId);

        TravelView GetViewById(int travelId);

        IQueryable<TravelView> GetAll();

        int Save();
               
    }
}
