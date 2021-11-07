using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Cities;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.World
{
    public interface ICityService
    {
        bool AddCity(CityAddDTO dto);

        bool UpdateCity(CityUpdateDTO dto);

        bool DeleteCity(int cityId);

        GridResultDTO<CityDTO> GetAllCity(int skip, int take);
               
        bool IsCityExist(string name, int countryId);

        bool IsCityExist(string name, int countryId, int cityId);

        CityDTO GetCityById(int cityId);

    }
}
