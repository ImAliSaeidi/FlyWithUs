using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Travels;
using FlyWithUs.Hosted.Service.Models.Travels;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.Travels
{
    public interface ITravelService
    {
        bool AddTravel(TravelAddDTO dto);

        bool DeleteTravel(int travelid);

        bool UpdateTravel(TravelUpdateDTO dto);

        TravelDTO GetTravelById(int travelid);

        GridResultDTO<TravelView> GetAllTravel(int skip, int take);

        GridResultDTO<TravelView> SearchTravel(int skip, int take, TravelSearchDTO dto);

        TravelUpdateDTO GetTravelForUpdate(int travelid);

        bool AddTicket(int travelid, string userid);
    }
}
