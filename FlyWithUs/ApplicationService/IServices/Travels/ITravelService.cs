using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Travels;
using System.Collections.Generic;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.Travels
{
    public interface ITravelService
    {
        bool AddTravel(TravelAddDTO dto);

        bool DeleteTravel(int travelid);

        bool UpdateTravel(TravelUpdateDTO dto);

        TravelDTO GetTravelById(int travelid);

        TravelViewDTO GetTravelViewById(int travelid);

        GridResultDTO<TravelViewDTO> GetAllTravel(int skip, int take);

        GridResultDTO<TravelViewDTO> SearchTravel(int skip, int take, TravelSearchDTO dto);

        TravelUpdateDTO GetTravelForUpdate(int travelid);

        
    }
}
