
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VortexdeCodeDL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
