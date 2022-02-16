using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power.Utilities.Helper
{
    public class PowerException : Exception
    {
        public string ErrorCode { get; private set; }
        public object ExceptionDate { get; set; }
        public PowerException() : base()
        {

        }

        public PowerException(string message, string errorCode)
            : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
