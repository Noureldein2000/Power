using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Power.Utilities.Helper
{
    public class MD5PasswordHasher<TUser> : PasswordHasher<TUser> where TUser : class
    {
        public override string HashPassword(TUser user, string password)
        {
            //byte[] keyByte2 = StringToByteArray("AF62343B314631632D663137362D342144332D615134392D39653163397533B3373762AF");
            //HMACSHA256 hmacsha256 = new HMACSHA256(keyByte2);
            //byte[] messageBytes = Encoding.UTF8.GetBytes(password);
            //byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
            //return ByteToString(hashmessage).ToLower();
            return base.HashPassword(user, password);
        }
        public override PasswordVerificationResult VerifyHashedPassword(TUser user, string hashedPassword, string providedPassword)
        {
            //byte[] decodedHashedPassword = Encoding.UTF8.GetBytes(hashedPassword);

            ////byte[] keyByte = Encoding.UTF8.GetBytes("AF62343B314631632D663137362D342144332D615134392D39653163397533B3373762AF");
            //byte[] keyByte2 = StringToByteArray("AF62343B314631632D663137362D342144332D615134392D39653163397533B3373762AF");

            //HMACSHA256 hmacsha256 = new HMACSHA256(keyByte2);
            //byte[] messageBytes = Encoding.UTF8.GetBytes(providedPassword);
            //byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
            //var newHasedPass = ByteToString(hashmessage).ToLower();
            //if (newHasedPass == hashedPassword)
            //    return PasswordVerificationResult.Success;
            //if (hashedPassword.Equals(newHasedPass))
            //    return PasswordVerificationResult.Success;
            return base.VerifyHashedPassword(user, hashedPassword, providedPassword);
        }
        private static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
        public string GetM5Hash(string input)
        {
            using MD5 md5Hash = MD5.Create();
            var bytes = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(bytes);
        }
        private static string ByteToString(byte[] buff)
        {
            string sbinary = "";

            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2"); // hex format
            }
            return (sbinary);
        }
    }
}
