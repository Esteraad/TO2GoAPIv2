using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TO2GoAPIv2.Data
{
    public class ApiUser : IdentityUser
    {
        public string Nick { get; set; }
    }
}
