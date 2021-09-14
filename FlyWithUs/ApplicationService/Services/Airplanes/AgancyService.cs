using FlyWithUs.Hosted.Service.ApplicationService.IServices.Airplanes;
using FlyWithUs.Hosted.Service.DTOs.Agancies;
using FlyWithUs.Hosted.Service.DTOs.Airplanes;
using FlyWithUs.Hosted.Service.Infrastructure.Repositories.Airplanes;
using FlyWithUs.Hosted.Service.Models.Airplanes;
using FlyWithUs.Hosted.Service.Tools.Convertors;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.Airplanes
{
    public class AgancyService : IAgancyService
    {
        private readonly AgancyRepository repository;
        public AgancyService()
        {
            repository = new AgancyRepository();
        }

        #region Add Agancy
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
        #endregion


        #region Get Agancy
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

        public AgancyDTO GetAgancyById(int agancyid)
        {
            return Map(repository.GetAgancyById(agancyid));
        }

        private AgancyDTO Map(Agancy agancy)
        {
            AgancyDTO dto = new AgancyDTO();
            dto.Id = agancy.Id;
            dto.Name = agancy.Name;
            dto.CreateDate = agancy.CreateDate.ToShamsi();
            dto.AirplaneDTOs = new List<AirplaneDTO>();
            foreach (var item in agancy.Airplanes)
            {
                dto.AirplaneDTOs.Add(Map(item));
            }
            return dto;
        }

        private AirplaneDTO Map(Airplane airplane)
        {
            return new AirplaneDTO
            {
                Id = airplane.Id,
                Name = airplane.Name,
                Brand = airplane.Brand,
                Count = airplane.Count,
                MaxCapacity = airplane.MaxCapacity
            };
        }
        #endregion


        #region Validation
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
        #endregion


        #region Delete Agancy
        public bool DeleteAgancy(int agancyid)
        {
            bool result = false;
            int count = repository.DeleteAgancy(agancyid);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }
        #endregion


        #region Update Agancy
        public AgancyUpdateDTO GetAgancyForUpdate(int agancyid)
        {
            var agancy = repository.GetAgancyById(agancyid);
            return new AgancyUpdateDTO
            {
                Id = agancy.Id,
                Name = agancy.Name
            };
        }

        public bool UpdateAgancy(AgancyUpdateDTO dto)
        {
            bool result = false;
            int count = repository.UpdateAgancy(Map(dto));
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        private Agancy Map(AgancyUpdateDTO dto)
        {
            var agancy = repository.GetAgancyById(dto.Id);
            agancy.Name = dto.Name.ToLower().Trim();
            return agancy;
        }
        #endregion


        #region Agancy As Select List
        public List<SelectListItem> GetAllAgancyAsSelectList()
        {
            return repository.GetAllAgancy()
                .Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();
        }
        #endregion

    }
}
