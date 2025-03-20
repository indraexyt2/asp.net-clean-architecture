using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Common.Exceptions
{
    public class BadRequestException : Exception
    {
        public string Status {  get; set; }
        public string[] Errors { get; set; }

        public BadRequestException(string status, string message) : base(message)
        {
            Status = status;
        }

        public BadRequestException(string status, string message, string[] errors) : base(message)
        {
            Status = status;
            Errors = errors;
        }
    }
}
