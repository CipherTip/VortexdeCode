using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VortexdeCodeDL.Models;

namespace VortexdeCodeDL.Data
{
    public class VortexDBContext: IdentityDbContext<ApplicationUser>
    {
        public VortexDBContext(DbContextOptions<VortexDBContext> options)
            : base(options)
        {
                    
        }
        public DbSet<Models.Issue> Issues { get; set; }
    }
}
