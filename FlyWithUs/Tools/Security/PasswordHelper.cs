using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FlyWithUs.Hosted.Service.Tools.Security
{
    public class PasswordHelper
    {
        public static string EncodePasswordSHA3(string pass)
        {
            var hashAlgorithm = new Org.BouncyCastle.Crypto.Digests.Sha3Digest(256);


            byte[] input = Encoding.ASCII.GetBytes(pass);

            hashAlgorithm.BlockUpdate(input, 0, input.Length);

            byte[] result = new byte[32]; // 512 / 8 = 64
            hashAlgorithm.DoFinal(result, 0);

            string hashString = BitConverter.ToString(result);
            hashString = hashString.Replace("-", "").ToLowerInvariant();

            return hashString;
        }
    }
}
