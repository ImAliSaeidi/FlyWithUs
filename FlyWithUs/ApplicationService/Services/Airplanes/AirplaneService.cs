using FlyWithUs.Hosted.Service.ApplicationService.IServices.Airplanes;
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
        public AirplaneService()
        {
            repository = new AirplaneRepository();
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
                Name = dto.Name,
                Brand = dto.Brand,
                MaxCapacity = dto.MaxCapacity,
                Agancy = dto.Agancy
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
                AgancyName = airplane.Agancy.Name
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
            airplane.Agancy = dto.Agancy;
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
                Agancy = airplane.Agancy
            };
        }
    }
}
