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
        public BadRequestException(string message) : base(message) { }

        public BadRequestException(string[] errors) : base("Terjadi beberapa kesalahan")
        {
            Errors = errors;
        }

        public string[] Errors { get; private set; }
    }
}
