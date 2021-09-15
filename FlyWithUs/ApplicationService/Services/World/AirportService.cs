using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using FlyWithUs.Hosted.Service.DTOs.Airports;
using FlyWithUs.Hosted.Service.Infrastructure.Repositories.World;
using FlyWithUs.Hosted.Service.Models.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.World
{
    public class AirportService : IAirportService
    {
        private readonly AirportRepository repository;
        private readonly CityRepository cityRepository;
        public AirportService()
        {
            repository = new AirportRepository();
            cityRepository = new CityRepository();
        }


        #region Add Airport
        public bool AddAirport(AirportAddDTO dto)
        {
            bool result = false;
            int id = repository.AddAirport(Map(dto));
            if (id > 0)
            {
                var airport = repository.GetAirportById(id);
                var city = cityRepository.GetCityById(dto.CityId);
                airport.City = city;
                city.Airports.Add(airport);
                cityRepository.UpdateCity(city);
                repository.UpdateAirport(airport);
                result = true;
            }
            return result;
        }

        private Airport Map(AirportAddDTO dto)
        {
            return new Airport
            {
                Name = dto.Name,
                EnglishName = dto.EnglishName,
                Code = dto.EnglishName.ToUpper().Trim().Substring(0, 4),
            };
        }
        #endregion


        #region Delete Airport
        public bool DeleteAirport(int airportid)
        {
            bool result = false;
            int count = repository.DeleteAirport(airportid);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }
        #endregion


        #region Get Airport
        public AirportDTO GetAirportById(int airportid)
        {
            return Map(repository.GetAirportById(airportid));
        }

        private AirportDTO Map(Airport airport)
        {
            return new AirportDTO
            {
                Id = airport.Id,
                Name = airport.Name,
                EnglishName = airport.EnglishName,
                Code = airport.Code,
                CityName = cityRepository.GetCityById(airport.City.Id).Name
            };
        }

        public List<AirportDTO> GetAllAirport()
        {
            List<AirportDTO> dtos = new List<AirportDTO>();
            List<Airport> airports = repository.GetAllAirport();
            foreach (var item in airports)
            {
                dtos.Add(Map(item));
            }
            return dtos;
        }
        #endregion


        #region Validation
        public bool IsAirportExist(string name, int cityid, int? airportid)
        {
            if (airportid != null)
            {
                bool result = false;
                var airport = repository.GetAirportById(airportid.Value);
                if (repository.IsAirportExist(name, cityid) == true)
                {
                    if (airport.Name == name && airport.City.Id == cityid)
                    {
                        result = false;
                    }
                    else
                    {
                        result = true;
                    }
                }
                return result;
            }
            else
            {
                return repository.IsAirportExist(name, cityid);
            }
        }
        #endregion


        #region Update Airport
        public bool UpdateAirport(AirportUpdateDTO dto)
        {
            bool result = false;
            int count = repository.UpdateAirport(Map(dto));
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        private Airport Map(AirportUpdateDTO dto)
        {
            var airport = repository.GetAirportById(dto.Id);
            var city = cityRepository.GetCityById(dto.CityId);
            airport.Name = dto.Name;
            airport.EnglishName = dto.EnglishName;
            airport.Code = dto.EnglishName.ToUpper().Trim().Substring(0, 4);
            if (airport.City.Id != dto.CityId)
            {
                airport.City = city;
                city.Airports.Add(airport);
                cityRepository.UpdateCity(city);
            }
            return airport;
        }

        public AirportUpdateDTO GetAirportForUpdate(int airportid)
        {
            var airport = repository.GetAirportById(airportid);
            return new AirportUpdateDTO
            {
                Id = airport.Id,
                Name = airport.Name,
                EnglishName = airport.EnglishName,
                CityId = airport.City.Id
            };
        }
        #endregion
    }
}
