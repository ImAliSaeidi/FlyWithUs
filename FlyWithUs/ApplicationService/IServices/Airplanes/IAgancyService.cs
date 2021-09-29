using FlyWithUs.Hosted.Service.DTOs;
using FlyWithUs.Hosted.Service.DTOs.Agancies;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.Airplanes
{
    public interface IAgancyService
    {
        GridResultDTO<AgancyDTO> GetAllAgancy(int skip, int take);

        bool AddAgancy(AgancyAddDTO dto);

        bool IsAgancyExist(string name, int? agancyid);

        bool DeleteAgancy(int agancyid);

        AgancyUpdateDTO GetAgancyForUpdate(int agancyid);

        bool UpdateAgancy(AgancyUpdateDTO dto);

        List<SelectListItem> GetAllAgancyAsSelectList();

        AgancyDTO GetAgancyById(int agancyid);
    }
}
