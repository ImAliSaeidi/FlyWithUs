using FlyWithUs.Hosted.Service.DTOs.Travels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.Travels
{
    public interface ITravelService
    {
        bool AddTravel(TravelAddDTO dto);

        bool DeleteTravel(int travelid);

        bool UpdateTravel(TravelUpdateDTO dto);

        TravelDTO GetTravelById(int travelid);

        List<TravelDTO> GetAllTravel();

        TravelUpdateDTO GetTravelForUpdate(int travelid);
    }
}
