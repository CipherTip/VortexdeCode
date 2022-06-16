using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VortexdeCodeDL.Data;

namespace VortexdeCodeDL.UnitOfWorkContext
{
    internal class OsUnitOfWorkContext : VortexDBContext, IOsUnitOfWorkContext
    {
        public OsUnitOfWorkContext(DbContextOptions<VortexDBContext> options)
            : base(options)
        {

        }
    }
}
