using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VortexdeCodeDL.RepositoryBase;

namespace VortexdeCodeDL.UnitOfWork
{
    internal interface IOsUnitOfWork : IDisposable
    {
        IGenericRepositoryBase<T> GetRepository<T>() where T : class;

        int Save();

        Task<int> SaveAsync();
    }
}
