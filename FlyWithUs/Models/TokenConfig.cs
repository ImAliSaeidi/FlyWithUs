using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Models
{
    public class TokenConfig
    {
        public static string Issuer { get; set; }

        public static string Audience { get; set; }

        public static string Key { get; set; }
    }
}
