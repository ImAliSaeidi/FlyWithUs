using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Countries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.World
{
    public interface ICountryService
    {
        List<SelectListItem> GetAllCountryAsSelectList();

        GridResultDTO<CountryDTO> GetAllCountry(int skip,int take);

        bool AddCountry(CountryAddDTO dto);

        bool DeleteCountry(int countryid);

        bool UpdateCountry(CountryUpdateDTO dto);

        CountryDTO GetCountryById(int countryid);

        bool IsExistCountry(string englishname,string persianname,short phonecode);

        bool IsExistCountry(string englishname,string persianname,short phonecode, int countryid);

        CountryUpdateDTO GetCountryForUpdate(int countryid);
    }
}
