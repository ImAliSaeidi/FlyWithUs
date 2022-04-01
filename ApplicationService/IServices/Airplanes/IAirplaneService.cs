using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Airplanes;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.Airplanes
{
    public interface IAirplaneService
    {
        bool AddAirplane(AirplaneAddDTO dto);

        bool UpdateAirplane(AirplaneUpdateDTO dto);

        bool DeleteAirplane(int airplaneId);

        GridResultDTO<AirplaneDTO> GetAllAirplane(int skip, int take);

        bool IsAirplaneExist(string name, string brand, int maxCapacity, int agancyId);

        bool IsAirplaneExist(string name, string brand, int maxCapacity, int agancyId, int airplaneId);

        AirplaneDTO GetAirplaneById(int airplaneId);

    }
}
