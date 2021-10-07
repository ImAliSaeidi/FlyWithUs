using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Cities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.World
{
    public interface ICityService
    {
        bool AddCity(CityAddDTO dto);

        bool UpdateCity(CityUpdateDTO dto);

        bool DeleteCity(int cityid);

        GridResultDTO<CityDTO> GetAllCity(int skip, int take);

        CityUpdateDTO GetCityForUpdate(int cityid);

        bool IsCityExist(string name, int countryid);

        bool IsCityExist(string name, int countryid, int cityid);

        List<SelectListItem> GetAllCityAsSelectList(int? countryid);

        CityDTO GetCityById(int cityid);
    }
}
