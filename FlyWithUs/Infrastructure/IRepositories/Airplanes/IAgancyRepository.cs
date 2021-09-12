using FlyWithUs.Hosted.Service.Models.Airplanes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Airplanes
{
    public interface IAgancyRepository
    {
        int AddAgancy(Agancy agancy);

        int DeleteAgancy(int agancyid);

        int UpdateAgancy(Agancy agancy);

        Agancy GetAgancyById(int agancyid);

        List<Agancy> GetAllAgancy();

        int Save();
    }
}
