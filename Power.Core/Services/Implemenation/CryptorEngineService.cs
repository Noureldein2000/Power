using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Power.Core.Services.Interface;
using Power.Utilities.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Power.Core.Services.Implemenation
{
    public class CryptorEngineService : ICryptorEngineService
    {
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private readonly IConfiguration _config;
        private readonly string key;
        private const string EncryptionKey = "0123456789ABCWBDCAFDTRGBDSCXSTUVWXYZ";
        public CryptorEngineService(IDataProtectionProvider dataProtectionProvider, IConfiguration config)
        {
            _dataProtectionProvider = dataProtectionProvider;
            _config = config;
            key = _config.GetSection("Cryptor:PublicKey").Value;
        }

        public string Encrypt(string input)
        {
            var protector = _dataProtectionProvider.CreateProtector(key);
            return protector.Protect(input);
        }

        public string Decrypt(string cipherText)
        {
            var protector = _dataProtectionProvider.CreateProtector(key);
            return protector.Unprotect(cipherText);
        }

        //------------------------------------For Encrypt and Decrypt String Implemented--------------------------------------------//
        public string EncryptString(string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes("AAECAwQFBgcICQoLDA0ODw==");
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using MemoryStream memoryStream = new();
                using CryptoStream cryptoStream = new((Stream)memoryStream, encryptor, CryptoStreamMode.Write);
                using (StreamWriter streamWriter = new((Stream)cryptoStream))
                {
                    streamWriter.Write(plainText);
                }
                array = memoryStream.ToArray();
            }

            return Convert.ToBase64String(array);
        }
        public string DecryptString(string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);
            using Aes aes = Aes.Create();
            //I have already defined "Key" in the above EncryptString function
            aes.Key = Encoding.UTF8.GetBytes("AAECAwQFBgcICQoLDA0ODw==");
            aes.IV = iv;
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using MemoryStream memoryStream = new(buffer);
            using CryptoStream cryptoStream = new((Stream)memoryStream, decryptor, CryptoStreamMode.Read);
            using StreamReader streamReader = new((Stream)cryptoStream);
            return streamReader.ReadToEnd();
        }

        //------------------------------------For Encrypt and Decrypt Number Implemented--------------------------------------------//

        /// <summary>
        ///  Encrypt Number to long string
        /// </summary>
        /// <param name="encryptString"></param>
        /// <returns></returns>
        public string EncryptNumber(string encryptString)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new(EncryptionKey, new byte[] {
                0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
            });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using MemoryStream ms = new();
                using (CryptoStream cs = new(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                encryptString = Convert.ToBase64String(ms.ToArray());
            }
            return encryptString;
        }

        /// <summary>
        /// Decrypt string to  orginal Number 
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public string DecryptNumber(string cipherText)
        {

            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new(EncryptionKey, new byte[] {
                0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
            });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using MemoryStream ms = new();
                using (CryptoStream cs = new(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
            return cipherText;
        }

    }
}
