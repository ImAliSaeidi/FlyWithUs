using System;
using System.Security.Cryptography;
using System.Text;

namespace FlyWithUs.Hosted.Service.Tools.Security
{
    public class HashGenerator
    {
        private static string Generate(string plaintext, string hashtype)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(plaintext);
            byte[] hashed = HashAlgorithm.Create(hashtype).ComputeHash(bytes);
            return Convert.ToBase64String(hashed);  
        }

        public static string SalterHash(string plaintext)
        {
            double cofficient = Math.Ceiling((double)(21 / 2));
            int length = (int)(plaintext.Length / cofficient);
            if (length == 0)
            {
                length = plaintext.Length / 2;
            }
            return Generate(plaintext, nameof(HashType.MD5)) + Generate(Reverse(plaintext, length), nameof(HashType.SHA1));

        }

        private static string Reverse(string plaintext, int length)
        {
            char[] reversetext = plaintext.ToCharArray();
            Array.Reverse(reversetext);
            return new string(reversetext).Substring(0, length);
        }
    }
}
