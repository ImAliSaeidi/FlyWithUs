using FlyWithUs.Hosted.Service.ApplicationService.IServices.Airplanes;
using FlyWithUs.Hosted.Service.DTOs.Airplanes;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Airplanes;
using FlyWithUs.Hosted.Service.Infrastructure.Repositories.Airplanes;
using FlyWithUs.Hosted.Service.Models.Airplanes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.Airplanes
{
    public class AirplaneService : IAirplaneService
    {
        private readonly IAirplaneRepository repository;
        private readonly IAgancyRepository agancyRepository;

        public AirplaneService(IAirplaneRepository repository, IAgancyRepository agancyRepository)
        {
            this.repository = repository;
            this.agancyRepository = agancyRepository;
        }


        #region Add Airplane
        public bool AddAirplane(AirplaneAddDTO dto)
        {
            bool result = false;
            int id = repository.AddAirplane(Map(dto));
            if (id > 0)
            {
                var airplane = repository.GetAirplaneById(id);
                var agancy = agancyRepository.GetAgancyById(dto.AgancyId);
                airplane.Agancy = agancy;
                agancy.Airplanes.Add(airplane);
                agancyRepository.UpdateAgancy(agancy);
                repository.UpdateAirplane(airplane);
                result = true;
            }
            return result;
        }

        private Airplane Map(AirplaneAddDTO dto)
        {
            Airplane airplane = new Airplane();
            airplane.Name = dto.Name;
            airplane.Brand = dto.Brand;
            airplane.MaxCapacity = dto.MaxCapacity;
            airplane.Count = dto.Count;
            return airplane;
        }
        #endregion


        #region Delete Airplane
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
        #endregion


        #region Get Airplane
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
                AgancyName = airplane.Agancy.Name,
                Count = airplane.Count
            };
        }
        #endregion


        #region Update Airplane
        public AirplaneUpdateDTO GetAirplaneForUpdate(int airplaneid)
        {
            var airplane = repository.GetAirplaneById(airplaneid);
            return new AirplaneUpdateDTO
            {
                Id = airplane.Id,
                Name = airplane.Name,
                Brand = airplane.Brand,
                MaxCapacity = airplane.MaxCapacity,
                AgancyId = airplane.Agancy.Id,
                Count = airplane.Count
            };
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
            var agancy = agancyRepository.GetAgancyById(dto.AgancyId);
            var airplane = repository.GetAirplaneById(dto.Id);
            airplane.Name = dto.Name;
            airplane.Brand = dto.Brand;
            airplane.MaxCapacity = dto.MaxCapacity;
            airplane.Count = dto.Count;
            if (airplane.Agancy.Id != dto.AgancyId)
            {
                airplane.Agancy = agancy;
                agancy.Airplanes.Add(airplane);
                agancyRepository.UpdateAgancy(agancy);
            }
            return airplane;
        }
        #endregion


        #region Validation
        public bool IsAirplaneExist(string name, string brand, int maxcapacity, int agancyid, int? airplaneid)
        {
            if (airplaneid != null)
            {
                bool result = false;
                Airplane airplane = repository.GetAirplaneById(airplaneid.Value);
                if (repository.IsAirplaneExist(name, brand, maxcapacity, agancyid) == true)
                {
                    if (airplane.Name == name && airplane.Brand == brand && airplane.MaxCapacity == maxcapacity &&
                    airplane.Agancy.Id == agancyid)
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

        public List<SelectListItem> GetAllAirplaneAsSelectList(int agancyid)
        {
            return repository.GetAllAirplane().Where(a => a.Agancy.Id == agancyid)
                .Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList();
        }

        public AirplaneDTO GetAirplaneById(int airplaneid)
        {
            return Map(repository.GetAirplaneById(airplaneid));
        }
        #endregion
    }
}
