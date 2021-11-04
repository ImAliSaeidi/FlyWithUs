using AutoMapper;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.Airplanes;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Airplanes;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Airplanes;
using FlyWithUs.Hosted.Service.Models.Airplanes;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.Airplanes
{
    public class AirplaneService : IAirplaneService
    {
        private readonly IAirplaneRepository repository;
        private readonly IMapper mapper;

        public AirplaneService(IAirplaneRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }


        public bool AddAirplane(AirplaneAddDTO dto)
        {
            bool result = false;
            if (IsAirplaneExist(dto.Name, dto.Brand, dto.MaxCapacity, dto.AgancyId) == false)
            {
                int count = repository.Add(mapper.Map<Airplane>(dto));
                if (count > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public bool DeleteAirplane(int airplaneId)
        {
            bool result = false;
            int count = repository.Delete(airplaneId);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public GridResultDTO<AirplaneDTO> GetAllAirplane(int skip, int take)
        {
            var dtos = mapper.Map<List<AirplaneDTO>>(repository.
                GetAll()
                .IgnoreQueryFilters()
                .Where(a => a.IsDeleted == false)
                .Skip(skip)
                .Take(take)
                .ToList());
            var count = repository.
                GetAll()
                .IgnoreQueryFilters()
                .Where(a => a.IsDeleted == false)
                .Count();
            return new GridResultDTO<AirplaneDTO>(count, dtos);
        }

        public AirplaneDTO GetAirplaneById(int airplaneId)
        {
            return mapper.Map<AirplaneDTO>(repository.GetById(airplaneId));
        }

        public AirplaneUpdateDTO GetAirplaneForUpdate(int airplaneId)
        {
            return mapper.Map<AirplaneUpdateDTO>(repository.GetById(airplaneId));
        }

        public bool UpdateAirplane(AirplaneUpdateDTO dto)
        {
            bool result = false;
            if (IsAirplaneExist(dto.Name, dto.Brand, dto.MaxCapacity, dto.AgancyId, dto.Id) == false)
            {
                int count = repository.Update(mapper.Map<Airplane>(dto));
                if (count > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public bool IsAirplaneExist(string name, string brand, int maxCapacity, int agancyId)
        {
            return repository.IsExist(name, brand, maxCapacity, agancyId);
        }

        public bool IsAirplaneExist(string name, string brand, int maxCapacity, int agancyId, int airplaneId)
        {
            bool result = false;
            var airplane = repository.GetById(airplaneId);
            if (repository.IsExist(name, brand, maxCapacity, agancyId) == true)
            {
                if (airplane.Name == name && airplane.Brand == brand && airplane.MaxCapacity == maxCapacity &&
                airplane.Agancy.Id == agancyId)
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

        public List<SelectListItem> GetAllAirplaneAsSelectList(int agancyId)
        {
            return repository.GetAll().Where(a => a.Agancy.Id == agancyId)
                .Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList();
        }

    }
}
