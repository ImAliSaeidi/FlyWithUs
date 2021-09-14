using FlyWithUs.Hosted.Service.DTOs.Cities;
using FlyWithUs.Hosted.Service.DTOs.Countries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.World
{
    interface ICountryService
    {
        List<SelectListItem> GetAllCountryForAddUser();

        List<CountryDTO> GetAllCountry();

        bool AddCountry(CountryAddDTO dto);

        bool DeleteCountry(int countryid);

        bool UpdateCountry(CountryUpdateDTO dto);

        CountryDTO GetCountryById(int countryid);

        bool IsExistCountry(string name, short numcode, short phonecode, int? countryid);

        CountryUpdateDTO GetCountryForUpdate(int countryid);
    }
}
