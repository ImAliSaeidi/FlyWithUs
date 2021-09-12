using FlyWithUs.Hosted.Service.DTOs.Agancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.Airplanes
{
   public interface IAgancyService
    {
        List<AgancyDTO> GetAllAgancy();

        bool AddAgancy(AgancyAddDTO dto);

        bool IsAgancyExist(string name, int? agancyid);

        bool DeleteAgancy(int agancyid);

        AgancyUpdateDTO GetAgancyForUpdate(int agancyid);

        bool UpdateAgancy(AgancyUpdateDTO dto);
    }
}
