using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Infrastructure.Common
{
    public class UserContext : IUserContext
    {
        public string UserId { get; set; }
    }
}
