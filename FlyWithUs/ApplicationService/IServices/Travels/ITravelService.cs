using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Travels;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.Travels
{
    public interface ITravelService
    {
        bool AddTravel(TravelAddDTO dto);

        bool DeleteTravel(int travelId);

        bool UpdateTravel(TravelUpdateDTO dto);

        TravelDTO GetTravelById(int travelId);

        TravelViewDTO GetTravelViewById(int travelId);

        GridResultDTO<TravelViewDTO> GetAllTravel(int skip, int take);

        GridResultDTO<TravelViewDTO> SearchTravel(int skip, int take, TravelSearchDTO dto);

        TravelUpdateDTO GetTravelForUpdate(int travelId);

        
    }
}
