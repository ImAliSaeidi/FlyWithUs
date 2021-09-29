using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Travels;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.Travels
{
    public interface ITravelService
    {
        bool AddTravel(TravelAddDTO dto);

        bool DeleteTravel(int travelid);

        bool UpdateTravel(TravelUpdateDTO dto);

        TravelDTO GetTravelById(int travelid);

        GridResultDTO<TravelDTO> GetAllTravel(int skip,int take);

        TravelUpdateDTO GetTravelForUpdate(int travelid);
    }
}
