using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.DTOs.Statistics
{
    public class StatisticsDTO
    {
        public long UsersCount { get; set; }

        public long OrdersCount { get; set; }

        public long CitiesCount { get; set; }

        public long TravelsCount { get; set; }
    }
}
