using FlyWithUs.Hosted.Service.ApplicationService.IServices.Travels;
using FlyWithUs.Hosted.Service.DTOs.Travels;
using FlyWithUs.Hosted.Service.Infrastructure.Repositories.Travels;
using FlyWithUs.Hosted.Service.Infrastructure.Repositories.World;
using FlyWithUs.Hosted.Service.Models.Travels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.ApplicationService.Services.Travels
{
    public class TravelService : ITravelService
    {
        private readonly TravelRepository repository;
        private readonly CityRepository cityRepository;
        public TravelService()
        {
            repository = new TravelRepository();
            cityRepository = new CityRepository();
        }


        #region Add Travel
        public bool AddTravel(TravelAddDTO dto)
        {
            bool result = false;
            int travelid = repository.AddTravel(Map(dto));
            if (travelid > 0)
            {
                var travel = repository.GetTravelById(travelid);
                var orgcity = cityRepository.GetCityById(dto.OriginCityId);
                var destcity = cityRepository.GetCityById(dto.DestinationCityId);
                travel.OriginCity = orgcity;
                travel.DestinationCity = destcity;
                orgcity.OutboundTravels.Add(travel);
                destcity.IncomingTravels.Add(travel);
                cityRepository.UpdateCity(orgcity);
                cityRepository.UpdateCity(destcity);
                repository.UpdateTravel(travel);
                result = true;
            }
            return result;
        }

        private Travel Map(TravelAddDTO dto)
        {
            string org = dto.OriginCityId.ToString();
            string dest = dto.DestinationCityId.ToString();

            return new Travel
            {
                Code = (org + dest + Guid.NewGuid()).Substring(0, 10)
            };
        }
        #endregion


        #region Delete Travel
        public bool DeleteTravel(int travelid)
        {
            bool result = false;
            int count = repository.DeleteTravel(travelid);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }
        #endregion


        #region Get Travel
        public List<TravelDTO> GetAllTravel()
        {
            List<TravelDTO> dtos = new List<TravelDTO>();
            List<Travel> travels = repository.GetAllTravel();
            foreach (var item in travels)
            {
                dtos.Add(Map(item));
            }
            return dtos;
        }

        public TravelDTO GetTravelById(int travelid)
        {
            return Map(repository.GetTravelById(travelid));
        }

        private TravelDTO Map(Travel travel)
        {
            return new TravelDTO
            {
                Id = travel.Id,
                Code = travel.Code,
                MaxCapacity = travel.MaxCapacity,
                OriginCityName = travel.OriginCity.Name,
                DestinationCityName = travel.DestinationCity.Name
            };
        }
        #endregion


        #region Update Travel
        public TravelUpdateDTO GetTravelForUpdate(int travelid)
        {
            var travel = repository.GetTravelById(travelid);
            return new TravelUpdateDTO
            {
                Id = travel.Id,
                OriginCityId = travel.OriginCity.Id,
                DestinationCityId = travel.DestinationCity.Id
            };
        }

        public bool UpdateTravel(TravelUpdateDTO dto)
        {
            bool result = false;
            int count = repository.UpdateTravel(Map(dto));
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        private Travel Map(TravelUpdateDTO dto)
        {
            var travel = repository.GetTravelById(dto.Id);
            if (travel.OriginCity.Id != dto.OriginCityId)
            {
                var orgcity = cityRepository.GetCityById(dto.OriginCityId);
                travel.OriginCity = orgcity;
                orgcity.OutboundTravels.Add(travel);
                cityRepository.UpdateCity(orgcity);
            }
            if (travel.DestinationCity.Id != dto.DestinationCityId)
            {
                var destcity = cityRepository.GetCityById(dto.DestinationCityId);
                travel.DestinationCity = destcity;
                destcity.IncomingTravels.Add(travel);
                cityRepository.UpdateCity(destcity);
            }
            string org = dto.OriginCityId.ToString();
            string dest = dto.DestinationCityId.ToString();
            travel.Code = (org + dest + Guid.NewGuid()).Substring(0, 10);
            return travel;
        }
        #endregion
    }
}
