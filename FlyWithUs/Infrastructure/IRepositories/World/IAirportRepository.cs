using FlyWithUs.Hosted.Service.Models.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World
{
    public interface IAirportRepository
    {
        int AddAirport(Airport airport);

        int UpdateAirport(Airport airport);

        int DeleteAirport(int airportid);

        Airport GetAirportById(int airportid);

        List<Airport> GetAllAirport();

        bool IsAirportExist(string name, int cityid);

        int Save();
    }
}
