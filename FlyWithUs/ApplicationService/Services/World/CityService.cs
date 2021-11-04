using AutoMapper;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Airports;
using FlyWithUs.Hosted.Service.DTOs.Cities;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World;
using FlyWithUs.Hosted.Service.Models;
using FlyWithUs.Hosted.Service.Models.World;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.World
{
    public class CityService : ICityService
    {
        private readonly ICityRepository repository;
        private readonly ICountryRepository countryRepository;
        private readonly IMapper mapper;

        public CityService(ICityRepository repository, IMapper mapper, ICountryRepository countryRepository)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.countryRepository = countryRepository;
        }

        public bool AddCity(CityAddDTO dto)
        {
            var result = false;
            if (IsCityExist(dto.PersianName, dto.CountryId) == false)
            {
                var city = mapper.Map<City>(dto);
                int count = repository.Add(city);
                if (count > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        //private static void SaveCityImage(string directoryName, IFormFile image)
        //{
        //    var destinationPath = CreateDirectory(directoryName);
        //    destinationPath = destinationPath + "\\" + image.FileName;
        //    using (Stream stream = new FileStream(destinationPath, FileMode.Create))
        //    {
        //        image.CopyTo(stream);
        //    }
        //}

        //private static string CreateDirectory(string directoryName)
        //{
        //    var directoryPath = CDNConfiguration.FileUrl + ImagePaths.CityImagePath + directoryName;
        //    if (!Directory.Exists(directoryPath))
        //    {
        //        Directory.CreateDirectory(directoryPath);
        //    }
        //    return directoryPath;
        //}

        public bool DeleteCity(int cityId)
        {
            bool result = false;
            int count = repository.Delete(cityId);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public GridResultDTO<CityDTO> GetAllCity(int skip, int take)
        {
            var dtos = mapper.Map<List<CityDTO>>(repository.GetAll().Skip(skip).Take(take).ToList());
            var count = repository.GetAll().Count();
            foreach (var dto in dtos)
            {
                dto.CountryName = countryRepository.GetById(dto.CountryId).PersianName;
            }

            return new GridResultDTO<CityDTO>(count, dtos);
        }

        public CityDTO GetCityById(int cityId)
        {
            return Map(repository.GetById(cityId));
        }

        private CityDTO Map(City city)
        {
            CityDTO dto = mapper.Map<CityDTO>(city);
            foreach (var item in city.Airports)
            {
                dto.AirportDTOs.Add(mapper.Map<AirportDTO>(item));
            }
            return dto;
        }

        public CityUpdateDTO GetCityForUpdate(int cityId)
        {
            return mapper.Map<CityUpdateDTO>(repository.GetById(cityId));
        }

        public bool UpdateCity(CityUpdateDTO dto)
        {
            bool result = false;
            if (IsCityExist(dto.PersianName, dto.CountryId, dto.Id) == false)
            {
                var city = mapper.Map<City>(dto);
                int count = repository.Update(city);
                if (count > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public bool IsCityExist(string persianName, int countryId)
        {
            return repository.IsExist(persianName, countryId);
        }

        public bool IsCityExist(string persianName, int countryId, int cityId)
        {
            bool result = false;
            var city = repository.GetById(cityId);
            if (repository.IsExist(persianName, countryId) == true)
            {
                if (city.PersianName == persianName && city.Country.Id == countryId)
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

        public List<CityDTO> GetAllCityAsSelectList(int countryId)
        {
            return mapper.Map<List<CityDTO>>(repository
                         .GetAll()
                         .Where(c => c.Country.Id == countryId)
                         .ToList());
        }


        public List<PopularDestinationDTO> GetPopularDestinations()
        {
            return mapper
                .Map<List<PopularDestinationDTO>>
                (repository.GetPopularDestinations()
                .Skip(0)
                .Take(6)
                .OrderByDescending(p => p.TravelCount)
                .ToList());
        }

    }
}
