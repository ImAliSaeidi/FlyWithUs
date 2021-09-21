using FlyWithUs.Hosted.Service.DTOs.Airports;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.World
{
    public interface IAirportService
    {
        bool AddAirport(AirportAddDTO dto);

        bool UpdateAirport(AirportUpdateDTO dto);

        bool DeleteAirport(int airportid);

        AirportDTO GetAirportById(int airportid);

        List<AirportDTO> GetAllAirport();

        bool IsAirportExist(string name, int cityid, int? airportid);

        AirportUpdateDTO GetAirportForUpdate(int airportid);

        List<SelectListItem> GetAllAirportAsSelectList(int cityid);
    }
}
