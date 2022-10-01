using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Helpers
{
    public static class HashHelper
    {
        private static readonly int salt_length = 16;
        private static readonly int hash_length = 32;
        private static readonly int iteration = 1000;

        public static string Hash(string password)
        {

            byte[] salt;
            byte[] buffer;

            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, salt_length, iteration))
            {
                salt = bytes.Salt;
                buffer = bytes.GetBytes(hash_length);
            }

            byte[] dst = new byte[(salt_length + hash_length) + 1];
            Buffer.BlockCopy(salt, 0, dst, 1, salt_length);
            Buffer.BlockCopy(buffer, 0, dst, 17, hash_length);
            return Convert.ToBase64String(dst);
        }

        public static bool CheckHash(string password, string hashPassword)
        {
            if (hashPassword == null || password == null)
                return false;

            byte[] src = Convert.FromBase64String(hashPassword);
            if (src.Length != (salt_length + hash_length + 1) || src[0] != 0)
                return false;

            byte[] buffer4;
            byte[] dst = new byte[salt_length];
            Buffer.BlockCopy(src, 1, dst, 0, salt_length);
            byte[] buffer3 = new byte[hash_length];
            Buffer.BlockCopy(src, 17, buffer3, 0, 32);

            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, iteration))
            {
                buffer4 = bytes.GetBytes(32);
            }

            return buffer3.SequenceEqual(buffer4);
        }


    }
}
