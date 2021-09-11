using FlyWithUs.Hosted.Service.DTOs.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.World
{
    interface ICountryService
    {
        List<CountryDTO> GetAllCountry();
    }
}
