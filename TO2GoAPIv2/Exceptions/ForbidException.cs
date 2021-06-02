using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TO2GoAPIv2.Models;

namespace TO2GoAPIv2.Exceptions
{
    public class ForbidException : Exception
    {
        public ForbidError ForbidError { get; set; }

        public ForbidException(string message, ForbidError forbidError) : base(message) {
            ForbidError = forbidError;
        }
    }
}
