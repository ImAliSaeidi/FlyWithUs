﻿using AutoMapper;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.World;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Airports;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.World;
using FlyWithUs.Hosted.Service.Models.World;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.World
{
    public class AirportService : IAirportService
    {
        private readonly IAirportRepository repository;
        private readonly IMapper mapper;

        public AirportService(IAirportRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public bool AddAirport(AirportAddDTO dto)
        {
            bool result = false;
            int count = repository.Add(mapper.Map<Airport>(dto));
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public bool DeleteAirport(int airportid)
        {
            bool result = false;
            int count = repository.Delete(airportid);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public AirportDTO GetAirportById(int airportid)
        {
            return mapper.Map<AirportDTO>(repository.GetById(airportid));
        }

        public List<SelectListItem> GetAllAirportAsSelectList(int cityid)
        {
            return repository.GetAll().Where(a => a.City.Id == cityid)
               .Select(c => new SelectListItem()
               {
                   Text = c.Name,
                   Value = c.Id.ToString()
               }).ToList();
        }

        public GridResultDTO<AirportDTO> GetAllAirport(int skip, int take)
        {
            var airports = repository.GetAll().Skip(skip).Take(take).ToList();
            var dtos = new List<AirportDTO>();
            foreach (var item in airports)
            {
                var dto = mapper.Map<AirportDTO>(item);
                dto.CityName = item.City.PersianName;
                dtos.Add(dto);
            }
            var count = repository.GetAll().Count();
            return new GridResultDTO<AirportDTO>(count, dtos);
        }

        public bool IsAirportExist(string name, int cityid)
        {
            return repository.IsExist(name, cityid);
        }

        public bool IsAirportExist(string name, int cityid, int airportid)
        {
            bool result = false;
            var airport = repository.GetById(airportid);
            if (repository.IsExist(name, cityid) == true)
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

        public bool UpdateAirport(AirportUpdateDTO dto)
        {
            bool result = false;
            int count = repository.Update(mapper.Map<Airport>(dto));
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public AirportUpdateDTO GetAirportForUpdate(int airportid)
        {
            return mapper.Map<AirportUpdateDTO>(repository.GetById(airportid));
        }

    }
}
