using AutoMapper;
using FlyWithUs.Hosted.Service.ApplicationService.IServices.Airplanes;
using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Airplanes;
using FlyWithUs.Hosted.Service.Infrastructure.IRepositories.Airplanes;
using FlyWithUs.Hosted.Service.Models.Airplanes;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            int count = repository.Add(mapper.Map<Airplane>(dto));
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public bool DeleteAirplane(int airplaneid)
        {
            bool result = false;
            int count = repository.Delete(airplaneid);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public GridResultDTO<AirplaneDTO> GetAllAirplane(int skip, int take)
        {
            var dtos = mapper.Map<List<AirplaneDTO>>(repository.GetAll().Skip(skip).Take(take).ToList());
            var count = repository.GetAll().Count();
            return new GridResultDTO<AirplaneDTO>(count, dtos);
        }

        public AirplaneDTO GetAirplaneById(int airplaneid)
        {
            return mapper.Map<AirplaneDTO>(repository.GetById(airplaneid));
        }

        public AirplaneUpdateDTO GetAirplaneForUpdate(int airplaneid)
        {
            return mapper.Map<AirplaneUpdateDTO>(repository.GetById(airplaneid));
        }

        public bool UpdateAirplane(AirplaneUpdateDTO dto)
        {
            bool result = false;
            int count = repository.Update(mapper.Map<Airplane>(dto));
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public bool IsAirplaneExist(string name, string brand, int maxcapacity, int agancyid)
        {
            return repository.IsExist(name, brand, maxcapacity, agancyid);
        }

        public bool IsAirplaneExist(string name, string brand, int maxcapacity, int agancyid, int airplaneid)
        {
            bool result = false;
            var airplane = repository.GetById(airplaneid);
            if (repository.IsExist(name, brand, maxcapacity, agancyid) == true)
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

        public List<SelectListItem> GetAllAirplaneAsSelectList(int agancyid)
        {
            return repository.GetAll().Where(a => a.Agancy.Id == agancyid)
                .Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList();
        }

    }
}
