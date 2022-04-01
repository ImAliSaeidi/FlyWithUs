using AutoMapper;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.Airplanes;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Agancies;
using FlyWithUs.Hosted.Service.DTOs.Airplanes;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Airplanes;
using FlyWithUs.Hosted.Service.Models.Airplanes;
using System.Collections.Generic;
using System.Linq;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.Airplanes
{
    public class AgancyService : IAgancyService
    {
        private readonly IAgancyRepository repository;
        private readonly IMapper mapper;

        public AgancyService(IAgancyRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }


        public bool AddAgancy(AgancyAddDTO dto)
        {
            bool result = false;
            if (IsAgancyExist(dto.Name.ToLower().Trim()) == false)
            {
                dto.Name = dto.Name.ToLower().Trim();
                int count = repository.Add(mapper.Map<Agancy>(dto));
                if (count > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public GridResultDTO<AgancyDTO> GetAllAgancy(int skip, int take)
        {
            var dtos = mapper.Map<List<AgancyDTO>>(repository.GetAll().Skip(skip).Take(take).ToList());
            var count = repository.GetAll().Count();
            return new GridResultDTO<AgancyDTO>(count, dtos);
        }

        public AgancyDTO GetAgancyById(int agancyId)
        {
            var agancy = repository.GetById(agancyId);
            var agancydto = mapper.Map<AgancyDTO>(agancy);
            foreach (var item in agancy.Airplanes)
            {
                agancydto.AirplaneDTOs.Add(mapper.Map<AirplaneDTO>(item));
            }
            return agancydto;
        }

        public bool IsAgancyExist(string name)
        {
            return repository.IsExist(name);
        }

        public bool IsAgancyExist(string name, int agancyId)
        {
            bool result = false;
            var agancy = repository.GetById(agancyId);
            if (repository.IsExist(name) == true && agancy.Name != name)
            {
                result = true;
            }
            return result;
        }

        public bool DeleteAgancy(int agancyId)
        {
            bool result = false;
            int count = repository.Delete(agancyId);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public bool UpdateAgancy(AgancyUpdateDTO dto)
        {
            bool result = false;
            if (IsAgancyExist(dto.Name.ToLower().Trim(), dto.Id) == false)
            {
                dto.Name = dto.Name.ToLower().Trim();
                int count = repository.Update(mapper.Map<Agancy>(dto));
                if (count > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public List<AgancyDTO> GetAllAgancyAsSelectList()
        {
            var agancies = repository.GetAll().ToList();
            var dtos = new List<AgancyDTO>();
            foreach (var agancy in agancies)
            {
                var dto = mapper.Map<AgancyDTO>(agancy);
                foreach (var airplane in agancy.Airplanes)
                {
                    dto.AirplaneDTOs.Add(mapper.Map<AirplaneDTO>(airplane));
                }
                dtos.Add(dto);
            }
            return dtos;
        }

    }
}
