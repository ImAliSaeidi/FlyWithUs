using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Agancies;
using System.Collections.Generic;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.Airplanes
{
    public interface IAgancyService
    {
        GridResultDTO<AgancyDTO> GetAllAgancy(int skip, int take);

        bool AddAgancy(AgancyAddDTO dto);

        bool IsAgancyExist(string name);

        bool IsAgancyExist(string name, int agancyId);

        bool DeleteAgancy(int agancyId);

        bool UpdateAgancy(AgancyUpdateDTO dto);

        List<AgancyDTO> GetAllAgancyAsSelectList();

        AgancyDTO GetAgancyById(int agancyId);
    }
}
