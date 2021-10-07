using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Airports;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.World
{
    public interface IAirportService
    {
        bool AddAirport(AirportAddDTO dto);

        bool UpdateAirport(AirportUpdateDTO dto);

        bool DeleteAirport(int airportid);

        AirportDTO GetAirportById(int airportid);

        GridResultDTO<AirportDTO> GetAllAirport(int skip, int take);

        bool IsAirportExist(string name, int cityid);

        bool IsAirportExist(string name, int cityid, int airportid);

        AirportUpdateDTO GetAirportForUpdate(int airportid);

        List<SelectListItem> GetAllAirportAsSelectList(int cityid);
    }
}
