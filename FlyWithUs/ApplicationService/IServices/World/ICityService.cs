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

        bool DeleteCity(int cityId);

        GridResultDTO<CityDTO> GetAllCity(int skip, int take);

        CityUpdateDTO GetCityForUpdate(int cityId);

        bool IsCityExist(string name, int countryId);

        bool IsCityExist(string name, int countryId, int cityId);

        List<CityDTO> GetAllCityAsSelectList(int countryId);

        CityDTO GetCityById(int cityId);

        List<PopularDestinationDTO> GetPopularDestinations();
    }
}
