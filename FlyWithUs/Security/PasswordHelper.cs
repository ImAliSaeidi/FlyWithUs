using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Security
{
    public class PasswordHelper
    {
        public static string EncodePasswordSHA3(string pass)
        {
            var hashAlgorithm = SHA256.Create();
            byte[] hashvalue = Encoding.ASCII.GetBytes(pass);
            byte[] result = hashAlgorithm.ComputeHash(hashvalue);
            return result.ToString();
        }
    }
}
