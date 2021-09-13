﻿using FlyWithUs.Hosted.Service.ApplicationService.IServices.Airplanes;
using FlyWithUs.Hosted.Service.DTOs.Airplanes;
using FlyWithUs.Hosted.Service.Infrastructure.Repositories.Airplanes;
using FlyWithUs.Hosted.Service.Models.Airplanes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.Airplanes
{
    public class AirplaneService : IAirplaneService
    {
        private readonly AirplaneRepository repository;
        private readonly AgancyService agancyService;
        public AirplaneService()
        {
            repository = new AirplaneRepository();
            agancyService = new AgancyService();
        }

        public bool AddAirplane(AirplaneAddDTO dto)
        {
            bool result = false;
            int count = repository.AddAirplane(Map(dto));
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        private Airplane Map(AirplaneAddDTO dto)
        {
            return new Airplane
            {
                Name = dto.Name.ToLower().Trim(),
                Brand = dto.Brand.ToLower().Trim(),
                MaxCapacity = dto.MaxCapacity,
                AgancyId = dto.AgancyId,
                Count = dto.Count
            };
        }

        public bool DeleteAirplane(int airplaneid)
        {
            bool result = false;
            int count = repository.DeleteAirplane(airplaneid);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public List<AirplaneDTO> GetAllAirplane()
        {
            List<AirplaneDTO> dtos = new List<AirplaneDTO>();
            List<Airplane> airplanes = repository.GetAllAirplane();
            foreach (var item in airplanes)
            {
                dtos.Add(Map(item));
            }
            return dtos;
        }

        private AirplaneDTO Map(Airplane airplane)
        {
            return new AirplaneDTO
            {
                Id = airplane.Id,
                Name = airplane.Name,
                Brand = airplane.Brand,
                MaxCapacity = airplane.MaxCapacity,
                AgancyName = agancyService.GetAgancyById(airplane.AgancyId).Name,
                Count = airplane.Count
            };
        }

        public List<AirplaneDTO> GetAllAirplaneByAgancy(int agancyid)
        {
            List<AirplaneDTO> dtos = new List<AirplaneDTO>();
            List<Airplane> airplanes = repository.GetAllAirplaneByAgancy(agancyid);
            foreach (var item in airplanes)
            {
                dtos.Add(Map(item));
            }
            return dtos;
        }

        public bool UpdateAirplane(AirplaneUpdateDTO dto)
        {
            bool result = false;
            int count = repository.UpdateAirplane(Map(dto));
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        private Airplane Map(AirplaneUpdateDTO dto)
        {
            var airplane = repository.GetAirplaneById(dto.Id);
            airplane.Name = dto.Name;
            airplane.Brand = dto.Brand;
            airplane.MaxCapacity = dto.MaxCapacity;
            airplane.AgancyId = dto.AgancyId;
            airplane.Count = dto.Count;
            return airplane;
        }

        public AirplaneUpdateDTO GetAirplaneForUpdate(int airplaneid)
        {
            var airplane = repository.GetAirplaneById(airplaneid);
            return new AirplaneUpdateDTO
            {
                Id = airplane.Id,
                Name = airplane.Name,
                Brand = airplane.Brand,
                MaxCapacity = airplane.MaxCapacity,
                AgancyId = airplane.AgancyId,
                Count = airplane.Count
            };
        }

        public bool IsAirplaneExist(string name, string brand, int maxcapacity, int agancyid, int? airplaneid)
        {
            if (airplaneid != null)
            {
                bool result = false;
                Airplane airplane = repository.GetAirplaneById(airplaneid.Value);
                if (repository.IsAirplaneExist(name, brand, maxcapacity, agancyid) == true)
                {
                    if (airplane.Name == name && airplane.Brand == brand && airplane.MaxCapacity == maxcapacity &&
                    airplane.AgancyId == agancyid)
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
                return repository.IsAirplaneExist(name, brand, maxcapacity, agancyid);
            }
        }
    }
}
