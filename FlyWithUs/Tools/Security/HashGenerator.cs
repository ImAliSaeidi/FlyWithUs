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
            return Generate(plaintext, nameof(HashType.MD5)) + Generate(plaintext.Substring(0, (int)(plaintext.Length / cofficient)), nameof(HashType.SHA1));

        }
    }
}
