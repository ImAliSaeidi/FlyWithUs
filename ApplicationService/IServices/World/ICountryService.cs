using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Countries;
using System.Collections.Generic;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.World
{
    public interface ICountryService
    {
        GridResultDTO<CountryDTO> GetAllCountry(int skip, int take);

        List<CountryListDTO> GetAllCountryForAPI();

        bool AddCountry(CountryAddDTO dto);

        bool DeleteCountry(int countryId);

        bool UpdateCountry(CountryUpdateDTO dto);

        CountryDTO GetCountryById(int countryId);

        bool IsExistCountry(string englishName, string persianName);

        bool IsExistCountry(string englishName, string persianName, int countryId);

        List<CountryDTO> GetAllWithoutPaging();
    }
}
