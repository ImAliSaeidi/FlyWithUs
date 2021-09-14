using FlyWithUs.Hosted.Service.DTOs.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.World
{
    public interface ICityService
    {
        bool AddCity(CityAddDTO dto);

        bool UpdateCity(CityUpdateDTO dto);

        bool DeleteCity(int cityid);

        CityDTO GetCityById(int cityid);

        List<CityDTO> GetAllCity();

        CityUpdateDTO GetCityForUpdate(int cityid);

        bool IsCityExist(string name, int countryid, int? cityid);
    }
}
