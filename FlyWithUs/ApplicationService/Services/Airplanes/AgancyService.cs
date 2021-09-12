﻿using FlyWithUs.Hosted.Service.ApplicationService.IServices.Airplanes;
using FlyWithUs.Hosted.Service.DTOs.Agancies;
using FlyWithUs.Hosted.Service.Infrastructure.Repositories.Airplanes;
using FlyWithUs.Hosted.Service.Models.Airplanes;
using FlyWithUs.Hosted.Service.Tools.Convertors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.Airplanes
{
    public class AgancyService : IAgancyService
    {
        private readonly AgancyRepository repository;
        public AgancyService()
        {
            repository = new AgancyRepository();
        }

        public bool AddAgancy(AgancyAddDTO dto)
        {
            bool result = false;
            int count = repository.AddAgancy(Map(dto));
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        private Agancy Map(AgancyAddDTO dto)
        {
            return new Agancy
            {
                Name = dto.Name.ToLower().Trim()
            };
        }

        public List<AgancyDTO> GetAllAgancy()
        {
            List<AgancyDTO> dtos = new List<AgancyDTO>();
            List<Agancy> agancies = repository.GetAllAgancy();
            foreach (var item in agancies)
            {
                dtos.Add(Map(item));
            }
            return dtos;
        }
        private AgancyDTO Map(Agancy agancy)
        {
            return new AgancyDTO
            {
                Id = agancy.Id,
                Name = agancy.Name,
                CreateDate = agancy.CreateDate.ToShamsi()
            };
        }

        public bool IsAgancyExist(string name, int? agancyid)
        {
            if (agancyid != null)
            {
                bool result = false;
                var agancy = repository.GetAgancyById(agancyid.Value);
                if (repository.IsAgancyExist(name) == true && agancy.Name != name)
                {
                    result = true;
                }
                return result;
            }
            else
            {
                return repository.IsAgancyExist(name);
            }
        }
    }
}