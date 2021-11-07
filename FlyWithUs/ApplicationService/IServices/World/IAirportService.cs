using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Airports;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.World
{
    public interface IAirportService
    {
        bool AddAirport(AirportAddDTO dto);

        bool UpdateAirport(AirportUpdateDTO dto);

        bool DeleteAirport(int airportId);

        AirportDTO GetAirportById(int airportId);

        GridResultDTO<AirportDTO> GetAllAirport(int skip, int take);

        bool IsAirportExist(string name, int cityId);

        bool IsAirportExist(string name, int cityId, int airportId);
    }
}
