using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Airplanes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.Airplanes
{
    public interface IAirplaneService
    {
        bool AddAirplane(AirplaneAddDTO dto);

        bool UpdateAirplane(AirplaneUpdateDTO dto);

        bool DeleteAirplane(int airplaneId);

        GridResultDTO<AirplaneDTO> GetAllAirplane(int skip, int take);

        AirplaneUpdateDTO GetAirplaneForUpdate(int airplaneId);

        bool IsAirplaneExist(string name, string brand, int maxCapacity, int agancyId);

        bool IsAirplaneExist(string name, string brand, int maxCapacity, int agancyId, int airplaneId);

        List<SelectListItem> GetAllAirplaneAsSelectList(int agancyid);

        AirplaneDTO GetAirplaneById(int airplaneId);

    }
}
