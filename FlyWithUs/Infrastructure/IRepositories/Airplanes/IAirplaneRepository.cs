using FlyWithUs.Hosted.Service.Models.Airplanes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Airplanes
{
    public interface IAirplaneRepository
    {
        int AddAirplane(Airplane airplane);

        int UpdateAirplane(Airplane airplane);

        int DeleteAirplane(int airplaneid);

        Airplane GetAirplaneById(int airplaneid);

        List<Airplane> GetAllAirplane();

        int Save();

        bool IsAirplaneExist(string name, string brand, int maxcapacity, int agancyid);
    }
}
