using System;
using System.Security.Cryptography;
using System.Text;

namespace DeviceManager.Utilities
{
    public class PasswordHelper
    {
        // Create password MD5
        public static string EncodePasswordMd5(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString().ToLower();
        }

        // Verify password
        public static bool VerifyPasswordStringType(string pass1, string pass2)
        {
            if (pass1.Equals(pass2))
                return true;
            else
                return false;
        }

        // Verify password hashed
        public static bool VerifyPasswordHashType(string pass1, string pass2)
        {
            if (EncodePasswordMd5(pass1).Equals(EncodePasswordMd5(pass2)))
                return true;
            else
                return false;
        }
    }
}