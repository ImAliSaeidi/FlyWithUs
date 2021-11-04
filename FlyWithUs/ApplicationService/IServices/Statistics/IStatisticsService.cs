using FlyWithUs.Hosted.Service.DTOs.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.ApplicationService.IServices.Statistics
{
    public interface IStatisticsService
    {
        StatisticsDTO GetStatistics();
    }
}
