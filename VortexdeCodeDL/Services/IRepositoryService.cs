using System;
using Microsoft.EntityFrameworkCore;
using VortexdeCodeDL.Data;
using VortexdeCodeDL.RepositoryBase;

namespace VortexdeCodeDL.Services
{
    internal interface IRepositoryService
    {
        VortexDBContext DbContext { get; set; }

        IGenericRepositoryBase<T> GetGenericRepository<T>() where T : class;

        T GetCustomRepository<T>(Func<VortexDBContext, object> factory = null) where T : class;
    }
}
