using FlyWithUs.Hosted.Service.Models.Travels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Travels
{
    public interface ITravelRepository
    {
        int AddTravel(Travel travel);

        int DeleteTravel(int travelid);

        int UpdateTravel(Travel travel);

        Travel GetTravelById(int travelid);

        List<Travel> GetAllTravel();

        int Save();
    }
}
