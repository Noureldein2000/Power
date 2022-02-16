using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power.Core.Services.Interface
{
    public interface ICryptorEngineService
    {
        public string Encrypt(string input);
        public string Decrypt(string output);
        public string EncryptString(string plainText);
        public string DecryptString(string plainText);
        public string EncryptNumber(string plainText);
        public string DecryptNumber(string plainText);
    }
}
