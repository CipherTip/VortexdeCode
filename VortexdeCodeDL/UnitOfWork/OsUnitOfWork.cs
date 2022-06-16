using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VortexdeCodeDL.Data;
using VortexdeCodeDL.RepositoryBase;
using VortexdeCodeDL.Services;

namespace VortexdeCodeDL.UnitOfWork
{
    internal class OsUnitOfWork : IOsUnitOfWork
    {
        private readonly VortexDBContext _dbContext;
        private readonly IRepositoryService _repositoryService;

        public OsUnitOfWork(VortexDBContext dbContext)
        {
            _dbContext = dbContext;

            if (_repositoryService == null)
            {
                _repositoryService = new RepositoryServiceImpl();
            }

            _repositoryService.DbContext = _dbContext;
        }

        int IOsUnitOfWork.Save()
        {
            return _dbContext.SaveChanges();
        }

        Task<int> IOsUnitOfWork.SaveAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        void IDisposable.Dispose()
        {
            _dbContext.Dispose();
        }

        IGenericRepositoryBase<T> IOsUnitOfWork.GetRepository<T>()
        {
            return _repositoryService.GetGenericRepository<T>();
        }
    }
}
